using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelBlogAgain.Migrations
{
    public partial class Suggestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    HasBeenVisited = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Upvotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });

            migrationBuilder.AlterColumn<double>(
                name: "Lon",
                table: "Locations",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "Locations",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.AlterColumn<int>(
                name: "Lon",
                table: "Locations",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Lat",
                table: "Locations",
                nullable: false);
        }
    }
}
