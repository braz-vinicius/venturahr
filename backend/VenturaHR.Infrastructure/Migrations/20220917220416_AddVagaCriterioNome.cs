using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenturaHR.Infrastructure.Migrations
{
    public partial class AddVagaCriterioNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "VagaCriterios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "VagaCriterios",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "VagaCriterios");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "VagaCriterios",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
