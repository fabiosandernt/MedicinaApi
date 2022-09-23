using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicina.Repository.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Pis = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatriculaEsocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoExame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataExame = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aso_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Risco = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaFuncionario",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaFuncionario", x => new { x.EmpresasId, x.FuncionariosId });
                    table.ForeignKey(
                        name: "FK_EmpresaFuncionario_Empresa_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaFuncionario_Funcionario_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aso_FuncionarioId",
                table: "Aso",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioId",
                table: "Empresa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaFuncionario_FuncionariosId",
                table: "EmpresaFuncionario",
                column: "FuncionariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aso");

            migrationBuilder.DropTable(
                name: "EmpresaFuncionario");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
