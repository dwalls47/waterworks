using Microsoft.EntityFrameworkCore.Migrations;

namespace GrpcService.Data.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Iterations",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Iterations", "Salt" },
                values: new object[] { "Mya4WGifV2DdfbGXueYGMKBZlvLLfBAwa8j2avEzqhs=", 1, "M91nsG2qR7vk4AS8TYA/vQFyHaQaVEQG9E004+XPzTY=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Iterations", "Salt" },
                values: new object[] { "jHjOEJL4QnFSz2P4jSPV7mbNILD8bEdF6LPCsQr8WTI=", 1, "J5uONlHya6G1w4NV3l70F0wa+vEw0df1jb+42PEAlyM=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iterations",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "HashedPassword",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "HashedPassword",
                value: "user");
        }
    }
}
