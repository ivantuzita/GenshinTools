using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinTools.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomainLocationURL",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "TalentMaterial",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "TalentMaterialPictureURL",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WeekDays",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "DomainLocationURL",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TalentMaterial",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TalentMaterialPictureURL",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "WeekDays",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "AscensionMaterialId",
                table: "Weapons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAscensionMaterial",
                table: "Weapons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AscensionMaterialId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAscensionMaterial",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TalentMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PictureURL = table.Column<string>(type: "TEXT", nullable: false),
                    WeekDays = table.Column<string>(type: "TEXT", nullable: false),
                    DomainLocationURL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentMaterials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AscensionMaterialId",
                table: "Weapons",
                column: "AscensionMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AscensionMaterialId",
                table: "Characters",
                column: "AscensionMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_TalentMaterials_AscensionMaterialId",
                table: "Characters",
                column: "AscensionMaterialId",
                principalTable: "TalentMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_TalentMaterials_AscensionMaterialId",
                table: "Weapons",
                column: "AscensionMaterialId",
                principalTable: "TalentMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_TalentMaterials_AscensionMaterialId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_TalentMaterials_AscensionMaterialId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "TalentMaterials");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_AscensionMaterialId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AscensionMaterialId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AscensionMaterialId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "IdAscensionMaterial",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "AscensionMaterialId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "IdAscensionMaterial",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "DomainLocationURL",
                table: "Weapons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TalentMaterial",
                table: "Weapons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TalentMaterialPictureURL",
                table: "Weapons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeekDays",
                table: "Weapons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DomainLocationURL",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TalentMaterial",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TalentMaterialPictureURL",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeekDays",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
