using AutoMapper;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Cadastro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Service
{
    public class FuncionarioService: IFuncionarioService
    {
            
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IMapper mapper;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.mapper = mapper;
        }

        public async Task<FuncionarioOutputDto> Criar(FuncionarioInputDto dto)
        {
            var funcionario = this.mapper.Map<Medicina.Domain.Cadastro.Funcionario>(dto);

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
