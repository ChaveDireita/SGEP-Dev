using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGEP.Migrations
{
    public partial class Migracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    Demitido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Unidade = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(27, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoAlocacoes",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Solicitante = table.Column<ulong>(nullable: false),
                    ProjSolicitante = table.Column<ulong>(nullable: false),
                    MaterialMovimentado = table.Column<ulong>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoAlocacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoCompras",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    MaterialMovimentado = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoCompras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    PrazoEstimado = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Unidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipaProjeto",
                columns: table => new
                {
                    CodFuncionario = table.Column<ulong>(nullable: false),
                    CodProjeto = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipaProjeto", x => new { x.CodFuncionario, x.CodProjeto });
                    table.ForeignKey(
                        name: "FK_ParticipaProjeto_Funcionario_CodFuncionario",
                        column: x => x.CodFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipaProjeto_Projeto_CodProjeto",
                        column: x => x.CodProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Quantidade = table.Column<ulong>(nullable: false),
                    CodMaterial = table.Column<ulong>(nullable: false),
                    CodProjeto = table.Column<ulong>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => new { x.CodMaterial, x.CodProjeto });
                    table.ForeignKey(
                        name: "FK_Transacao_Material_CodMaterial",
                        column: x => x.CodMaterial,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacao_Projeto_CodProjeto",
                        column: x => x.CodProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipaProjeto_CodProjeto",
                table: "ParticipaProjeto",
                column: "CodProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CodProjeto",
                table: "Transacao",
                column: "CodProjeto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoAlocacoes");

            migrationBuilder.DropTable(
                name: "MovimentacaoCompras");

            migrationBuilder.DropTable(
                name: "ParticipaProjeto");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
