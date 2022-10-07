using AutoMapper;
using Medicina.Domain.Account;
using Medicina.Domain.Account.Repository;
using Medicina.Domain.Cadastro.Repository;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<EmpresaOutputDto> Criar(EmpresaInputDto dto, Guid usuarioId)
        {
            if (await empresaRepository.AnyAsync(x => x.Cnpj == dto.Cnpj))
                throw new Exception("Já existe uma empresa cadastrado com o mesmo CNPJ");

            var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);
            empresa.UsuarioId = usuarioId;

            await this.empresaRepository.Save(empresa);
            return this.mapper.Map<EmpresaOutputDto>(empresa);

        }

        public async Task<EmpresaOutputDto> Deletar(EmpresaInputDto dto, Guid usuarioId)
        {
            if (await empresaRepository.AnyAsync(x => x.Cnpj == dto.Cnpj))
            {
                var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);
                empresa.UsuarioId = usuarioId;

                await this.empresaRepository.Delete(empresa);
                return this.mapper.Map<EmpresaOutputDto>(empresa);
            }
            else
            {
                throw new Exception("Este CNPJ não existe.");

            }
        }
        public async Task<EmpresaOutputDto> Atualizar(EmpresaInputDto dto, Guid usuarioId)
        {

            if (await empresaRepository.AnyAsync(x => x.Cnpj == dto.Cnpj))
            {                   
                var empresa = this.mapper.Map<Medicina.Domain.Cadastro.Empresa>(dto);
                empresa.UsuarioId = usuarioId;

                await this.empresaRepository.Update(empresa);
                return this.mapper.Map<EmpresaOutputDto>(empresa);
            }
            else
            {
                throw new Exception("Este CNPJ não existe.");
            }                      

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
