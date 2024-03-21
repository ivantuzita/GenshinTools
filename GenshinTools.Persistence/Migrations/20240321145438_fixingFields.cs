using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinTools.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HowToObtainMaterial",
                table: "Weapons",
                newName: "DomainLocationURL");

            migrationBuilder.RenameColumn(
                name: "HowToObtainMaterial",
                table: "Characters",
                newName: "DomainLocationURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DomainLocationURL",
                table: "Weapons",
                newName: "HowToObtainMaterial");

            migrationBuilder.RenameColumn(
                name: "DomainLocationURL",
                table: "Characters",
                newName: "HowToObtainMaterial");
        }
    }
}
