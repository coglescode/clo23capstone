using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSO.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedLastnameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                schema: "fso",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                schema: "fso",
                table: "Members");
        }
    }
}
