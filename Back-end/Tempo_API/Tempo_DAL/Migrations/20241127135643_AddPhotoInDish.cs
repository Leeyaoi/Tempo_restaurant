using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoInDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Dish",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Dish");
        }
    }
}
