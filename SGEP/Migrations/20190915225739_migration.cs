using Microsoft.EntityFrameworkCore.Migrations;

namespace SGEP.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Projeto",
                table: "Funcionario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Projeto",
                table: "Funcionario");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Material",
                nullable: true);
        }
    }
}
