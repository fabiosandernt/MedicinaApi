using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> ObterPorId(Guid id);
    }
}
