using AutoMapper;
using Medicina.Application.AzureBlob;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Cadastro.Repository;
using Medicina.Domain.Exame.Repository;
using static Medicina.Application.Exame.Dto.AsoDto;

namespace Medicina.Application.Exame.Service
{
    public class AsoService: IAsoService
    {
        private readonly IAsoRepository asoRepository;
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IMapper mapper;
        private readonly AzureBlobStorage storage;

        public AsoService(IAsoRepository asoRepository, IFuncionarioRepository funcionarioRepository, IMapper mapper, AzureBlobStorage storage)
        {
            this.asoRepository = asoRepository;
            this.funcionarioRepository = funcionarioRepository;
            this.mapper = mapper;
            this.storage = storage;
        }

        public async Task<AsoOutputDto> Criar(AsoInputDto dto)
        {

            var url = await storage.UploadBase64(dto.Imagem, "images");

            var funcionario = await this.funcionarioRepository.ObterTodosFuncionariosPorCpf(dto.Cpf);
            var funcionarioId = funcionario.FirstOrDefault()?.Id;       
            
            var aso = this.mapper.Map<Medicina.Domain.Exame.Aso>(dto);
            aso.FuncionarioId = funcionarioId.Value;
            aso.Imagem = url;
            await this.asoRepository.Save(aso);
            return this.mapper.Map<AsoOutputDto>(aso);

        }

        public async Task<AsoOutputDto> Deletar(AsoInputDto dto)
        {
            var aso = this.mapper.Map<Medicina.Domain.Exame.Aso>(dto);

            await this.asoRepository.Delete(aso);

            return this.mapper.Map<AsoOutputDto>(aso);

        }

        public async Task<AsoOutputDto> Atualizar(AsoInputDto dto)
        {
            var aso = this.mapper.Map<Medicina.Domain.Exame.Aso>(dto);

            await this.asoRepository.Update(aso);

            return this.mapper.Map<AsoOutputDto>(aso);

        }

        public async Task<List<AsoOutputDto>> ObterTodos()
        {
            var aso = await this.asoRepository.GetAll();

            return this.mapper.Map<List<AsoOutputDto>>(aso);
        }

        public async Task<AsoOutputDto> ObterPorId(Guid id)
        {
            var aso = await this.asoRepository.Get(id);

            return this.mapper.Map<AsoOutputDto>(aso);

        }
    }
}
