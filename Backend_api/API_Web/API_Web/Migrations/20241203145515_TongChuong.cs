using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Web.Migrations
{
    /// <inheritdoc />
    public partial class TongChuong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Chuong",
                table: "Khoa_Hoc",
                newName: "TongChuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TongChuong",
                table: "Khoa_Hoc",
                newName: "Chuong");
        }
    }
}
