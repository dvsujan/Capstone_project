using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CofeeStoreManagement.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOptionCategories_ProductOptions_ProductOptionOptionId",
                table: "ProductOptionCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductOptionCategories_ProductOptionOptionId",
                table: "ProductOptionCategories");

            migrationBuilder.DropColumn(
                name: "ProductOptionOptionId",
                table: "ProductOptionCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductOptionOptionId",
                table: "ProductOptionCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionCategories_ProductOptionOptionId",
                table: "ProductOptionCategories",
                column: "ProductOptionOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOptionCategories_ProductOptions_ProductOptionOptionId",
                table: "ProductOptionCategories",
                column: "ProductOptionOptionId",
                principalTable: "ProductOptions",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
