using Microsoft.EntityFrameworkCore.Migrations;

namespace SGEP.Migrations
{
    public partial class puto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Material",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Material",
                newName: "Nome");
        }
    }
}
