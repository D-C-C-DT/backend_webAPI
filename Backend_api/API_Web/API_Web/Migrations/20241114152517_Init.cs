using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Web.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Danh_Muc",
                columns: table => new
                {
                    Id_DM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_DM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danh_Muc", x => x.Id_DM);
                });

            migrationBuilder.CreateTable(
                name: "Khoa_Hoc",
                columns: table => new
                {
                    Id_KH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten_Khoa_Hoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mieu_ta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tong_Thoi_Gian = table.Column<int>(type: "int", nullable: false),
                    Chuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    GiamGia = table.Column<byte>(type: "tinyint", nullable: false),
                    Url_Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_DM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa_Hoc", x => x.Id_KH);
                    table.ForeignKey(
                        name: "FK_Khoa_Hoc_Danh_Muc_Id_DM",
                        column: x => x.Id_DM,
                        principalTable: "Danh_Muc",
                        principalColumn: "Id_DM");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_Hoc_Id_DM",
                table: "Khoa_Hoc",
                column: "Id_DM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khoa_Hoc");

            migrationBuilder.DropTable(
                name: "Danh_Muc");
        }
    }
}
