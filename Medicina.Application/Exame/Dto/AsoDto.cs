using Medicina.Domain.Account.ValueObject;
using Medicina.Domain.Cadastro;
using Medicina.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Dto
{
    public record UsuarioInputDto(
        Guid? Id,
        [Required(ErrorMessage = "O nome é requerido!")] string Name,
        [Required(ErrorMessage = "o Tipo é requerido!")] TipoUsuarioEnum TipoUsuario, 
        [Required(ErrorMessage = "A Senha é requerida!")] Password Password, 
        [Required(ErrorMessage = "O Email é requerido!")] Email Email
    );

    public record UsuarioOutputDto(Guid Id, string Name, TipoUsuarioEnum TipoUsuario, Email Email);

    public record EmpresaInputDto(string RazaoSocial, Email Email, string Endereco, string Celular, string Telefone, int Risco);
    public record EmpresaOutputDto(Guid Id, string RazaoSocial, Email Email, string Endereco, string Celular, string Telefone, int Risco);

    public record FuncionarioInputDto(string Name, string Setor, string Cpf, string Pis , DateTime? DataNascimento, string Funcao , string MatriculaEsocial);
    public record FuncionarioOutputDto(Guid Id, string Name, string Setor, string Cpf, string Pis, DateTime? DataNascimento, string Funcao, string MatriculaEsocial);

    public record AsoInputDto( string TipoExame, DateTime? DataExame ,string Imagem, Funcionario Funcionario );
    public record AsoOutputDto(Guid FuncionarioId , string TipoExame, DateTime? DataExame ,string Imagem, Funcionario Funcionario );

}
