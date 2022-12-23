using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasteleria.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaUseryrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "UserRole",
                newName: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserRole",
                newName: "Roles");
        }
    }
}
