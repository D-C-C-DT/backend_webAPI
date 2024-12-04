using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Web.Migrations
{
    /// <inheritdoc />
    public partial class NOTNULL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_Hoc_Danh_Muc_Id_DM",
                table: "Khoa_Hoc");

            migrationBuilder.AlterColumn<int>(
                name: "Id_DM",
                table: "Khoa_Hoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_Hoc_Danh_Muc_Id_DM",
                table: "Khoa_Hoc",
                column: "Id_DM",
                principalTable: "Danh_Muc",
                principalColumn: "Id_DM",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Khoa_Hoc_Danh_Muc_Id_DM",
                table: "Khoa_Hoc");

            migrationBuilder.AlterColumn<int>(
                name: "Id_DM",
                table: "Khoa_Hoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Khoa_Hoc_Danh_Muc_Id_DM",
                table: "Khoa_Hoc",
                column: "Id_DM",
                principalTable: "Danh_Muc",
                principalColumn: "Id_DM");
        }
    }
}
