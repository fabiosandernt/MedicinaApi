using Medicina.Domain.Account.ValueObject;
using Medicina.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Dto
{
    public record UsuarioInputDto(string Nome, TipoUsuarioEnum TipoUsuarioEnum, Password Password, Email Email);
    public record UsuarioOutputDto(Guid Id, string Nome, TipoUsuarioEnum TipoUsuarioEnum, Email Email);

    public record EmpresaInputDto(string RazaoSocial, Email Email, string Endereco, string Celular, string Telefone, int Risco);
    public record EmpresaOutputDto(Guid Id, string RazaoSocial, Email Email, string Endereco, string Celular, string Telefone, int Risco);

    public record FuncionarioInputDto(string Name, string Setor, string Cpf, string Pis , DateTime? DataNascimento, string Funcao , string MatriculaEsocial);
    public record FuncionarioOutputDto(Guid Id, string Name, string Setor, string Cpf, string Pis, DateTime? DataNascimento, string Funcao, string MatriculaEsocial);



}
