using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodMenuWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MenuItems",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pepperoni" },
                    { 2, "Cheese" },
                    { 3, "Tomato" },
                    { 4, "Basil" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "https://the-cafe.ru/wp-content/uploads/2020/11/523c10a1-464d-41ad-9d28-f414a009ae22.jpg", "Pepperoni", 10.0 },
                    { 2, null, "https://the-cafe.ru/wp-content/uploads/2020/11/147c3814bbb34a77afdbc66e9ef20ed7_584x584.jpeg", "Margherite", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "MenuItemIngredients",
                columns: new[] { "IngredientId", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MenuItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MenuItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MenuItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MenuItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MenuItemIngredients",
                keyColumns: new[] { "IngredientId", "MenuItemId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
