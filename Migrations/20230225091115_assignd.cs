using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing_System.Migrations
{
    public partial class assignd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Issues_issueId",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Labels_issueId",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "issueId",
                table: "Labels");

            migrationBuilder.CreateTable(
                name: "IssueLabel",
                columns: table => new
                {
                    issueId = table.Column<int>(type: "int", nullable: false),
                    listLabellabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLabel", x => new { x.issueId, x.listLabellabelId });
                    table.ForeignKey(
                        name: "FK_IssueLabel_Issues_issueId",
                        column: x => x.issueId,
                        principalTable: "Issues",
                        principalColumn: "issueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueLabel_Labels_listLabellabelId",
                        column: x => x.listLabellabelId,
                        principalTable: "Labels",
                        principalColumn: "labelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLabel_listLabellabelId",
                table: "IssueLabel",
                column: "listLabellabelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueLabel");

            migrationBuilder.AddColumn<int>(
                name: "issueId",
                table: "Labels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Labels_issueId",
                table: "Labels",
                column: "issueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Issues_issueId",
                table: "Labels",
                column: "issueId",
                principalTable: "Issues",
                principalColumn: "issueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
