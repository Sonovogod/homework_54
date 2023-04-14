using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileStore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNormalizeFieldAndAddIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedTitle",
                table: "Phones");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Phones",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedTitle",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
