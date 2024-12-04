using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Web.Migrations
{
    /// <inheritdoc />
    public partial class CHuongAndUser_KhoaHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Khoa_Hoc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chuong",
                columns: table => new
                {
                    Id_Chuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Id_KH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Khoa_hocsId_KH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chuong", x => x.Id_Chuong);
                    table.ForeignKey(
                        name: "FK_Chuong_Khoa_Hoc_Id_KH",
                        column: x => x.Id_KH,
                        principalTable: "Khoa_Hoc",
                        principalColumn: "Id_KH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chuong_Khoa_Hoc_Khoa_hocsId_KH",
                        column: x => x.Khoa_hocsId_KH,
                        principalTable: "Khoa_Hoc",
                        principalColumn: "Id_KH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id_DM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_DM = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id_DM);
                });

            migrationBuilder.CreateTable(
                name: "User_KhoaHocs",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_KH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_KhoaHocs", x => new { x.UserId, x.ID_KH });
                    table.ForeignKey(
                        name: "FK_User_KhoaHocs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_KhoaHocs_Khoa_Hoc_ID_KH",
                        column: x => x.ID_KH,
                        principalTable: "Khoa_Hoc",
                        principalColumn: "Id_KH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_Hoc_ApplicationUserId",
                table: "Khoa_Hoc",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_Hoc_Ten_Khoa_Hoc",
                table: "Khoa_Hoc",
                column: "Ten_Khoa_Hoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chuong_Id_KH",
                table: "Chuong",
                column: "Id_KH");

            migrationBuilder.CreateIndex(
                name: "IX_Chuong_Khoa_hocsId_KH",
                table: "Chuong",
                column: "Khoa_hocsId_KH");

            migrationBuilder.CreateIndex(
                name: "IX_Chuong_Name",
                table: "Chuong",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_Ten_DM",
                table: "DanhMuc",
                column: "Ten_DM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_KhoaHocs_ID_KH",
                table: "User_KhoaHocs",
                column: "ID_KH");

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_Hoc_AspNetUsers_ApplicationUserId",
                table: "Khoa_Hoc",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_Hoc_AspNetUsers_ApplicationUserId",
                table: "Khoa_Hoc");

            migrationBuilder.DropTable(
                name: "Chuong");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "User_KhoaHocs");

            migrationBuilder.DropIndex(
                name: "IX_Khoa_Hoc_ApplicationUserId",
                table: "Khoa_Hoc");

            migrationBuilder.DropIndex(
                name: "IX_Khoa_Hoc_Ten_Khoa_Hoc",
                table: "Khoa_Hoc");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Khoa_Hoc");
        }
    }
}
