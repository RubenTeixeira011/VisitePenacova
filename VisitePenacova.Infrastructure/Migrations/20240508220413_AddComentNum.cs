using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VisitePenacova.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddComentNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Locais",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ComentNums",
                columns: table => new
                {
                    Coment_Num = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentNums", x => x.Coment_Num);
                    table.ForeignKey(
                        name: "FK_ComentNums_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComentNums",
                columns: new[] { "Coment_Num", "Comentario", "LocalId" },
                values: new object[,]
                {
                    { 10, "Praia bastante limpa. Irei voltar certamente!", 1 },
                    { 11, "Água gelada!", 1 },
                    { 12, "Melhor praia flúvial do pais!", 1 },
                    { 13, "Praia com bandeira azul.", 1 },
                    { 21, "Um pedaço de história", 2 },
                    { 22, "Que órgão!", 2 },
                    { 23, "Vale a pena a visita!", 2 },
                    { 30, "Como é que isto existe?", 3 },
                    { 31, "Que dia bem passado! Já só penso em voltar!", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentNums_LocalId",
                table: "ComentNums",
                column: "LocalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentNums");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Locais",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);
        }
    }
}
