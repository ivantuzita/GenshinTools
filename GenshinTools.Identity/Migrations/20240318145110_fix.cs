using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinTools.Identity.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e45fdf0-ba32-4314-9d0c-88cda09191ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ab232fc-5353-49e6-89ed-8ebd18d8a947", "AQAAAAIAAYagAAAAEJ7mhdtRqn6clwEW1l5DfV6rY3xzqhw8ALnjBwSC5kDMq35aPCqM3QW1tQShANgNBw==", "11688f14-df72-4190-b13b-93f9fd167e0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6b21612-edc8-4dcf-8161-3462e8dc0577",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edd6dcfb-d53d-43d4-9923-e22244e06d5f", "AQAAAAIAAYagAAAAEF1+oZGtGJErtLC+3rwrH4faFjLH9iY+0VbjiaJggq0ZtXFA+9dQzaeVkNPg0OcgSQ==", "d01390ec-bcc5-4558-b36c-05c70a277212" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e45fdf0-ba32-4314-9d0c-88cda09191ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb843bac-34a9-42a4-af18-174102328757", "AQAAAAIAAYagAAAAELpa50czFbEnnBEf05XxOFacXd4Le10MyvEn9LFl/aFDl7NnVsiudFA9EJwr+YFDWA==", "68cd13d2-5cdc-4dda-b88b-3dc516cc80e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6b21612-edc8-4dcf-8161-3462e8dc0577",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "958cc45a-7f5e-4c0d-a052-725550c7b5eb", "AQAAAAIAAYagAAAAELhCqoSXGmlGkFBt0P2hjXqQCBuKxQ83r97wf9zuV5i09dsnasy3uStVDY4mIQwqKg==", "1a82c7da-f2d5-4a50-a8c6-9b7b0da1b93b" });
        }
    }
}
