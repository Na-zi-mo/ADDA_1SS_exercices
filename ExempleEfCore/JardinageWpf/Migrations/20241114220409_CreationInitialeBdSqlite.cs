using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JardinageWpf.Migrations
{
    /// <inheritdoc />
    public partial class CreationInitialeBdSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomCommun = table.Column<string>(type: "TEXT", nullable: false),
                    NomScientifique = table.Column<string>(type: "TEXT", nullable: false),
                    Hauteur = table.Column<double>(type: "REAL", nullable: false),
                    FamilleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantes_Familles_FamilleId",
                        column: x => x.FamilleId,
                        principalTable: "Familles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanteRegion",
                columns: table => new
                {
                    PlantesId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegionsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanteRegion", x => new { x.PlantesId, x.RegionsId });
                    table.ForeignKey(
                        name: "FK_PlanteRegion_Plantes_PlantesId",
                        column: x => x.PlantesId,
                        principalTable: "Plantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanteRegion_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Familles",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Graminé" },
                    { 2, "Orchidé" },
                    { 3, "Labié" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Désertique" },
                    { 2, "Aride" },
                    { 3, "Tempéré" }
                });

            migrationBuilder.InsertData(
                table: "Plantes",
                columns: new[] { "Id", "FamilleId", "Hauteur", "NomCommun", "NomScientifique" },
                values: new object[,]
                {
                    { 1, 1, 20.0, "Pissenlit", "Taraxacum officinale F.H. Wigg." },
                    { 2, 1, 50.0, "Blé", "Triticum turgidum ssp. durum" },
                    { 3, 2, 20.0, "Orchidée papillon", "Phalaenopsis" }
                });

            migrationBuilder.InsertData(
                table: "PlanteRegion",
                columns: new[] { "PlantesId", "RegionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Familles_Nom",
                table: "Familles",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanteRegion_RegionsId",
                table: "PlanteRegion",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantes_FamilleId",
                table: "Plantes",
                column: "FamilleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanteRegion");

            migrationBuilder.DropTable(
                name: "Plantes");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Familles");
        }
    }
}
