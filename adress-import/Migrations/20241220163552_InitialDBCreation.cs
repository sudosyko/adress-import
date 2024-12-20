using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adress_import.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmen",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firmenname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmen", x => x.FID);
                });

            migrationBuilder.CreateTable(
                name: "Ortschaften",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postleitzahl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ortschaften", x => x.OID);
                });

            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    AID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_FID = table.Column<int>(type: "int", nullable: false),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hausnummer = table.Column<int>(type: "int", nullable: false),
                    OrtschaftOID = table.Column<int>(type: "int", nullable: false),
                    FK_OID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.AID);
                    table.ForeignKey(
                        name: "FK_Adressen_Firmen_FK_OID",
                        column: x => x.FK_OID,
                        principalTable: "Firmen",
                        principalColumn: "FID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adressen_Ortschaften_OrtschaftOID",
                        column: x => x.OrtschaftOID,
                        principalTable: "Ortschaften",
                        principalColumn: "OID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_FK_OID",
                table: "Adressen",
                column: "FK_OID");

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_OrtschaftOID",
                table: "Adressen",
                column: "OrtschaftOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Firmen");

            migrationBuilder.DropTable(
                name: "Ortschaften");
        }
    }
}
