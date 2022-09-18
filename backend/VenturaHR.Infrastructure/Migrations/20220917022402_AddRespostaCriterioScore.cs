using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenturaHR.Infrastructure.Migrations
{
    public partial class AddRespostaCriterioScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Vagas_VagaId",
                table: "Respostas");

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VagaId",
                table: "Respostas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "Respostas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "RespostaCriterios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VagaCriterioId",
                table: "RespostaCriterios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RespostaCriterios_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_VagaCriterios_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId",
                principalTable: "VagaCriterios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Vagas_VagaId",
                table: "Respostas",
                column: "VagaId",
                principalTable: "Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_VagaCriterios_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Vagas_VagaId",
                table: "Respostas");

            migrationBuilder.DropIndex(
                name: "IX_RespostaCriterios_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.AlterColumn<int>(
                name: "VagaId",
                table: "Respostas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Vagas_VagaId",
                table: "Respostas",
                column: "VagaId",
                principalTable: "Vagas",
                principalColumn: "Id");
        }
    }
}
