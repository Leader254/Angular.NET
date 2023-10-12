using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class renamedcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ImgUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Products",
                newName: "ImageUrl");
        }
    }
}
