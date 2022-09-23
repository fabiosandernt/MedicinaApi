using AutoMapper;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Account.Repository;
using Medicina.Domain.Exame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Medicina.Domain.Account.Usuario>(dto);

            await this.usuarioRepository.Save(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Medicina.Domain.Account.Usuario>(dto);

            await this.usuarioRepository.Delete(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Medicina.Domain.Account.Usuario>(dto);

            await this.usuarioRepository.Update(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var usuario = await this.usuarioRepository.GetAll();

            return this.mapper.Map<List<UsuarioOutputDto>>(usuario);
        }

        public async Task<UsuarioOutputDto> ObterPorId(Guid id)
        {
            var usuario = await this.usuarioRepository.Get(id);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }
    }
}