using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP4.Migrations
{
    /// <inheritdoc />
    public partial class CreationInitialeBdSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Latitude", "Longitude", "Nom" },
                values: new object[,]
                {
                    { 1, 46.56984172477484, -72.738112856514419, "Shawinigan" },
                    { 2, 36.753799999999998, 3.0588000000000002, "Algiers" },
                    { 3, 35.697099999999999, -0.63080000000000003, "Oran" },
                    { 4, 36.365000000000002, 6.6147, "Constantine" },
                    { 5, 36.899999999999999, 7.766, "Annaba" },
                    { 6, 36.470100000000002, 2.8277000000000001, "Blida" },
                    { 7, 35.555, 6.1744000000000003, "Batna" },
                    { 8, 34.878300000000003, -1.3149999999999999, "Tlemcen" },
                    { 9, 36.192, 5.4138000000000002, "Sétif" },
                    { 10, 36.750900000000001, 5.0566000000000004, "Béjaïa" },
                    { 11, 32.4908, 3.6735000000000002, "Ghardaïa" },
                    { 12, 36.716999999999999, 4.0458999999999996, "Tizi Ouzou" },
                    { 13, 36.866199999999999, 6.9066999999999998, "Skikda" },
                    { 14, 34.8504, 5.7279999999999998, "Biskra" },
                    { 15, 27.876100000000001, -0.28320000000000001, "Adrar" },
                    { 16, 33.803600000000003, 2.8828999999999998, "Laghouat" },
                    { 17, 22.785, 5.5228000000000002, "Tamanrasset" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Nom",
                table: "Regions",
                column: "Nom",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
