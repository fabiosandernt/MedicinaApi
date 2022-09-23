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
    public class EmpresaService: IEmpresaService
    {
        private readonly IEmpresaRepository albumRepository;
        private readonly IMapper mapper;

        public EmpresaService(IEmpresaRepository albumRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
        }

        public async Task<EmpresaOutputDto> Criar(EmpresaInputDto dto)
        {
            var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);

            await this.albumRepository.Save(empresa);

            return this.mapper.Map<EmpresaOutputDto>(empresa);

        }

        public async Task<List<EmpresaOutputDto>> ObterTodos()
        {
            var empresa = await this.albumRepository.GetAll();

            return this.mapper.Map<List<EmpresaOutputDto>>(empresa);
        }
    }
}
