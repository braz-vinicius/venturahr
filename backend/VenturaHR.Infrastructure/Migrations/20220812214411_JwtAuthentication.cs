using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenturaHR.Infrastructure.Migrations
{
    public partial class JwtAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RespostaData",
                table: "Respostas",
                newName: "DataResposta");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Vagas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "DataResposta",
                table: "Respostas",
                newName: "RespostaData");
        }
    }
}
