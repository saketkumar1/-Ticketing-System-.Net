using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing_System.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_projectId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "projectId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_projectId",
                table: "Issues",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "projectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_projectId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "projectId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_projectId",
                table: "Issues",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
