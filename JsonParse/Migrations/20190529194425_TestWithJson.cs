using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JsonParse.Migrations
{
    public partial class TestWithJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ContaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    Resumo = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ContaId);
                    table.ForeignKey(
                        name: "FK_Conta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Email", "Fone", "Nome" },
                values: new object[] { 1, "carlos@carlao.com", "83988472514", "Carlos Carlão" });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 1, "Mensalidade academia", "14/25-25", 1, 49.990000000000002, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 2, "Conta de agua", "s/n", 1, 84.109999999999999, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 3, "Aluguel de carro", "52", 1, 149.0, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 4, "Aluguel de carro", "53", 1, 149.0, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 5, "Vacinas do cachorro que ficou doente após um passeio na praia", "1", 1, 32.409999999999997, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 6, "Mensalidade academia", "14/26", 1, 449.99000000000001, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 7, "Conta de luz", "s/n", 1, 44.780000000000001, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 8, "Aluguel de carro", "54", 1, 149.0, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "Resumo", "Titulo", "UsuarioId", "Valor", "Vencimento" },
                values: new object[] { 9, "Aluguel de carro", "55", 1, 149.0, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UsuarioId",
                table: "Conta",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
