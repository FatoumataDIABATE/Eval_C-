using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometrie.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCercle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cercles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    Rayon = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cercles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cercles_Points_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cercles_CentreId",
                table: "Cercles",
                column: "CentreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cercles");
        }
    }
}
