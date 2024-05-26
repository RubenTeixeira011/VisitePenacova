using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VisitePenacova.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocalToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locais",
                columns: new[] { "Id", "Categoria", "CreatedDate", "Descricao", "Freguesia", "ImageUrl", "Localidade", "Nome", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Praias fluviais", null, "Praia fluvial com bandeira azul", "São Pedro de Alva", "https://placehold.co/600x400", "Vimieiro", "Vimieiro", null },
                    { 2, "Monumentos históricos", null, "Monumento do século VI D.C", "Lorvão", "https://placehold.co/600x401", "Lorvão", "Mosteiro de Lorvão", null },
                    { 3, "Cascatas", null, "Cascata com pequena lagoa", "Figueira de Lorvão", "https://placehold.co/600x402", "Mata do Maxial", "Poço Grande", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locais",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
