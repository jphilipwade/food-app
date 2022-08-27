using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class IngredientQuantity_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientIngredientQuantity");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "IngredientQuantities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_IngredientId",
                table: "IngredientQuantities",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Ingredients_IngredientId",
                table: "IngredientQuantities",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Ingredients_IngredientId",
                table: "IngredientQuantities");

            migrationBuilder.DropIndex(
                name: "IX_IngredientQuantities_IngredientId",
                table: "IngredientQuantities");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "IngredientQuantities");

            migrationBuilder.CreateTable(
                name: "IngredientIngredientQuantity",
                columns: table => new
                {
                    IngredientQuantitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIngredientQuantity", x => new { x.IngredientQuantitiesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientIngredientQuantity_IngredientQuantities_IngredientQuantitiesId",
                        column: x => x.IngredientQuantitiesId,
                        principalTable: "IngredientQuantities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientIngredientQuantity_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIngredientQuantity_IngredientsId",
                table: "IngredientIngredientQuantity",
                column: "IngredientsId");
        }
    }
}
