using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon.Items.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfItems",
                schema: "Item",
                table: "Item",
                newName: "NumberOfAvailableItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Item",
                table: "Item",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Item",
                table: "Item",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Item",
                table: "Brand",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Item",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "NumberOfAvailableItems",
                schema: "Item",
                table: "Item",
                newName: "NumberOfItems");
        }
    }
}
