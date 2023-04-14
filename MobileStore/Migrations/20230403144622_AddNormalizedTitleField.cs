using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileStore.Migrations
{
    /// <inheritdoc />
    public partial class AddNormalizedTitleField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedTitle",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
            migrationBuilder.Sql($"UPDATE Phones " +
                                 $"SET NormalizedTitle = UPPER(Title)" +
                                 $"WHERE id > 0;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedTitle",
                table: "Phones");
        }
    }
}
