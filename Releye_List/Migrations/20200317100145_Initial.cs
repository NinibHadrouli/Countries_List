using Microsoft.EntityFrameworkCore.Migrations;

namespace Releye_List.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandLista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KundLista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(maxLength: 30, nullable: false),
                    LandListaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundLista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KundLista_LandLista_LandListaId",
                        column: x => x.LandListaId,
                        principalTable: "LandLista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KundLista_LandListaId",
                table: "KundLista",
                column: "LandListaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KundLista");

            migrationBuilder.DropTable(
                name: "LandLista");
        }
    }
}
