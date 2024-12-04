using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Web.Migrations
{
    /// <inheritdoc />
    public partial class Bai_Hoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bai_Hocs",
                columns: table => new
                {
                    Id_Lesson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_Lesson = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UrlVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    Id_Chuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bai_Hocs", x => x.Id_Lesson);
                    table.ForeignKey(
                        name: "FK_Bai_Hocs_Chuong_Id_Chuong",
                        column: x => x.Id_Chuong,
                        principalTable: "Chuong",
                        principalColumn: "Id_Chuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bai_Hocs_Id_Chuong",
                table: "Bai_Hocs",
                column: "Id_Chuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bai_Hocs");
        }
    }
}
