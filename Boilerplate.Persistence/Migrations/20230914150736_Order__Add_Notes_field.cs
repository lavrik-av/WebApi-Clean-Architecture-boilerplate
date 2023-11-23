using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boilerplate.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Order__Add_Notes_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "Notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Orders",
                newName: "Description");
        }
    }
}
