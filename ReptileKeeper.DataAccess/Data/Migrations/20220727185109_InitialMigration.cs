using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReptileKeeper.Web.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommunityScore",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KeeperScore",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PreyItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreySize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreyItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reptile",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgeInMonths = table.Column<int>(type: "int", nullable: false),
                    WeightInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reptile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reptile_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trophy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForReceiving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trophy_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedingLog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AteSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    DateFed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfNextFeed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreyItemId = table.Column<int>(type: "int", nullable: false),
                    QuantityFed = table.Column<int>(type: "int", nullable: false),
                    ReptileFedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedingLog_PreyItem_PreyItemId",
                        column: x => x.PreyItemId,
                        principalTable: "PreyItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedingLog_Reptile_ReptileFedId",
                        column: x => x.ReptileFedId,
                        principalTable: "Reptile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightLog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateWeighed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReptileWeighedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeightInGrams = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightLog_Reptile_ReptileWeighedId",
                        column: x => x.ReptileWeighedId,
                        principalTable: "Reptile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedingLog_PreyItemId",
                table: "FeedingLog",
                column: "PreyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingLog_ReptileFedId",
                table: "FeedingLog",
                column: "ReptileFedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reptile_OwnerId",
                table: "Reptile",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophy_RecipientId",
                table: "Trophy",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightLog_ReptileWeighedId",
                table: "WeightLog",
                column: "ReptileWeighedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedingLog");

            migrationBuilder.DropTable(
                name: "Trophy");

            migrationBuilder.DropTable(
                name: "WeightLog");

            migrationBuilder.DropTable(
                name: "PreyItem");

            migrationBuilder.DropTable(
                name: "Reptile");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CommunityScore",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KeeperScore",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
