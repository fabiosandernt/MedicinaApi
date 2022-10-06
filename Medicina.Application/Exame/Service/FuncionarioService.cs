using AutoMapper;
using Medicina.Application.Exame.Dto;
using Medicina.CrossCutting.Utils;
using Medicina.Domain.Cadastro;
using Medicina.Domain.Cadastro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Application.Exame.Service
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IMapper mapper;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IEmpresaRepository empresaRepository, IMapper mapper)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.empresaRepository = empresaRepository;
            this.mapper = mapper;
        }

        public async Task<FuncionarioOutputDto> Criar(FuncionarioInputDto dto)
        {

            var empresa = await this.empresaRepository.ObterTodasEmpresasPorCnpj(dto.Cnpj);
            var empresaId = empresa.FirstOrDefault()?.Id;

            var funcionario = this.mapper.Map<Medicina.Domain.Cadastro.Funcionario>(dto);

            funcionario.EmpresaId = empresaId.Value;

            await this.funcionarioRepository.Save(funcionario);

            return this.mapper.Map<FuncionarioOutputDto>(funcionario);


        }

        public async Task<FuncionarioOutputDto> Deletar(FuncionarioInputDto dto)
        {
            var funcionario = this.mapper.Map<Medicina.Domain.Cadastro.Funcionario>(dto);

            await this.funcionarioRepository.Delete(funcionario);

            return this.mapper.Map<FuncionarioOutputDto>(funcionario);

        }

        public async Task<FuncionarioOutputDto> Atualizar(FuncionarioInputDto dto)
        {
            var funcionario = this.mapper.Map<Medicina.Domain.Cadastro.Funcionario>(dto);

            await this.funcionarioRepository.Update(funcionario);

            return this.mapper.Map<FuncionarioOutputDto>(funcionario);

        }

        public async Task<List<FuncionarioOutputDto>> ObterTodos()
        {

            var funcionario = await this.funcionarioRepository.GetAll();

            return this.mapper.Map<List<FuncionarioOutputDto>>(funcionario);
        }

        public async Task<FuncionarioOutputDto> ObterPorId(Guid id)
        {
            var funcionario = await this.funcionarioRepository.Get(id);

            return this.mapper.Map<FuncionarioOutputDto>(funcionario);

        }
    }

}
