using AutoMapper;
using Medicina.Application.Exame.Dto;
using Medicina.CrossCutting.JwtService.Contracts;
using Medicina.CrossCutting.JwtService.Dto;
using Medicina.Domain.Account;
using Medicina.Domain.Account.Repository;
using Medicina.Domain.Account.ValueObject;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Application.Exame.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper mapper;
        private readonly IJwtService _jwtService;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IJwtService jwtService
        )
        {
            this._usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            _jwtService = jwtService;
        }


        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            if (await _usuarioRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var usuario = this.mapper.Map<Medicina.Domain.Account.Usuario>(dto);
            
            usuario.Validate();
            usuario.SetPassword();
            
            usuario.Id = Guid.NewGuid();

            await _usuarioRepository.Save(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<UsuarioOutputDto> Deletar([FromBody] UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Medicina.Domain.Account.Usuario>(dto);

            await this._usuarioRepository.Delete(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto)
        {
            if (!dto.Id.HasValue) throw new Exception("Usuário não encontrado");

            if (await _usuarioRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor && x.Id != dto.Id))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var usuario = await _usuarioRepository.GetbyExpressionAsync(x => x.Id == dto.Id.Value);
            if (usuario is null) throw new Exception("Usuário não encontrado");

            usuario.Update(dto.Name, dto.Email, dto.Password, dto.TipoUsuario);

            await this._usuarioRepository.Update(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            
            var usuario = await this._usuarioRepository.GetAll();

            return this.mapper.Map<List<UsuarioOutputDto>>(usuario);
        }

        public async Task<UsuarioOutputDto> ObterPorId(Guid id)
        {
            var usuario = await this._usuarioRepository.Get(id);

            return this.mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<string> ObterTokenJwtAsync(LoginDto dto)
        {
            var usuario = await _usuarioRepository.GetbyExpressionAsync(x => x.Email.Valor == dto.Email && x.Password.Valor == dto.Password);
            if (usuario is null) throw new Exception("Usuário não encontrado");

            return await _jwtService.GenerateToken(new JwtDto(usuario.Id, usuario.Email?.Valor));
        }
    }
}