using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartMenu.DbContext.Migrations
{
    public partial class add_food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCurrent = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    KeyName = table.Column<string>(nullable: true),
                    EntityKey = table.Column<Guid>(nullable: false),
                    FoodType = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MakingTime = table.Column<string>(nullable: true),
                    PhotoName = table.Column<string>(nullable: true),
                    FoodIngredients = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Food");
        }
    }
}
