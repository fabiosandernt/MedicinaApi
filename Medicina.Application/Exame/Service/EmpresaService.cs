using AutoMapper;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Cadastro;
using Medicina.Domain.Cadastro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.EmpresaDto;

namespace Medicina.Application.Exame.Service
{
    public class EmpresaService: IEmpresaService
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IMapper mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            this.empresaRepository = empresaRepository;
            this.mapper = mapper;
        }

        public async Task<EmpresaOutputDto> Criar(EmpresaInputDto dto)
        {
            var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);

            await this.empresaRepository.Save(empresa);

            return this.mapper.Map<EmpresaOutputDto>(empresa);

        }

        public async Task<EmpresaOutputDto> Deletar(EmpresaInputDto dto)
        {
            var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);

            await this.empresaRepository.Delete(empresa);

            return this.mapper.Map<EmpresaOutputDto>(empresa);

        }

        public async Task<EmpresaOutputDto> Atualizar(EmpresaInputDto dto)
        {
            var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);

            await this.empresaRepository.Update(empresa);

            return this.mapper.Map<EmpresaOutputDto>(empresa);

        }

        public async Task<List<EmpresaOutputDto>> ObterTodos()
        {
            var empresa = await this.empresaRepository.GetAll();

            return this.mapper.Map<List<EmpresaOutputDto>>(empresa);
        }

        public async Task<EmpresaOutputDto> ObterPorId(Guid id)
        {
            var empresa = await this.empresaRepository.Get(id);

            return this.mapper.Map<EmpresaOutputDto>(empresa);

        }
    }
}
