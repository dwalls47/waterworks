using Microsoft.EntityFrameworkCore.Migrations;

namespace GrpcService.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    MeterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.MeterId);
                });

            migrationBuilder.InsertData(
                table: "Meters",
                columns: new[] { "MeterId", "MeterNumber" },
                values: new object[,]
                {
                    { 1, "12345671" },
                    { 2, "12345672" },
                    { 3, "12345673" },
                    { 4, "12345674" },
                    { 5, "12345675" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
