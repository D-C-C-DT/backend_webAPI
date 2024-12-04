using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Web.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chuong_Khoa_Hoc_Khoa_hocsId_KH",
                table: "Chuong");

            migrationBuilder.DropIndex(
                name: "IX_Chuong_Khoa_hocsId_KH",
                table: "Chuong");

            migrationBuilder.DropColumn(
                name: "Khoa_hocsId_KH",
                table: "Chuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Khoa_hocsId_KH",
                table: "Chuong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Chuong_Khoa_hocsId_KH",
                table: "Chuong",
                column: "Khoa_hocsId_KH");

            migrationBuilder.AddForeignKey(
                name: "FK_Chuong_Khoa_Hoc_Khoa_hocsId_KH",
                table: "Chuong",
                column: "Khoa_hocsId_KH",
                principalTable: "Khoa_Hoc",
                principalColumn: "Id_KH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
