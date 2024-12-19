using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HEWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("39de6daf-ba70-451d-8f8a-1457c27c2535"), "Easy" },
                    { new Guid("3a5f8381-dc91-4c42-81b6-b141ab13fe86"), "Medium" },
                    { new Guid("a05591ce-005c-43bc-95e8-82519ccc057d"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("49cd0653-4674-4cf5-af26-a578a8137edd"), "AKL", "Auckland", "img-aucland.url" },
                    { new Guid("868b8f33-8fff-4a39-8cfd-685299f3b672"), "NGN", "Nigeria", "img-nigeria.url" },
                    { new Guid("edaa6e88-42b2-4a1e-a5ee-958072ff9480"), "STL", "Scotland", "img-stland.url" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("39de6daf-ba70-451d-8f8a-1457c27c2535"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3a5f8381-dc91-4c42-81b6-b141ab13fe86"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a05591ce-005c-43bc-95e8-82519ccc057d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("49cd0653-4674-4cf5-af26-a578a8137edd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("868b8f33-8fff-4a39-8cfd-685299f3b672"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("edaa6e88-42b2-4a1e-a5ee-958072ff9480"));
        }
    }
}
