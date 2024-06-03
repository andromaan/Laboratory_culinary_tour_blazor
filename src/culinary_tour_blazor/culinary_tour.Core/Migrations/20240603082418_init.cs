using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace culinary_tour.Core.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GastroFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingAvg = table.Column<decimal>(type: "decimal(2,1)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastroFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastroFacilities_FacilityTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastroFacilitieCuisine",
                columns: table => new
                {
                    CuisinesId = table.Column<int>(type: "int", nullable: false),
                    GastroFacilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastroFacilitieCuisine", x => new { x.CuisinesId, x.GastroFacilitiesId });
                    table.ForeignKey(
                        name: "FK_GastroFacilitieCuisine_Cuisines_CuisinesId",
                        column: x => x.CuisinesId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastroFacilitieCuisine_GastroFacilities_GastroFacilitiesId",
                        column: x => x.GastroFacilitiesId,
                        principalTable: "GastroFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Італійська" },
                    { 2, "Французька" },
                    { 3, "Іспанська" },
                    { 4, "Японська" },
                    { 5, "Китайська" },
                    { 6, "Індійська" },
                    { 7, "Тайська" },
                    { 8, "Мексиканська" },
                    { 9, "Грецька" },
                    { 10, "Турецька" },
                    { 11, "Українська" }
                });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Кафе" },
                    { 2, "Забігайлівка" },
                    { 3, "Ресторан" }
                });

            migrationBuilder.InsertData(
                table: "GastroFacilities",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "Photo", "RatingAvg", "TypeId" },
                values: new object[,]
                {
                    { new Guid("07208f86-692b-40be-938c-6fac756d4913"), "", null, "Заклад 1", null, 0m, 1 },
                    { new Guid("852f627c-83a2-47b7-917f-d722f181b959"), "", null, "Заклад 2", null, 0m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GastroFacilitieCuisine_GastroFacilitiesId",
                table: "GastroFacilitieCuisine",
                column: "GastroFacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_GastroFacilities_TypeId",
                table: "GastroFacilities",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GastroFacilitieCuisine");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "GastroFacilities");

            migrationBuilder.DropTable(
                name: "FacilityTypes");
        }
    }
}
