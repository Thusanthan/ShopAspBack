using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAspBack.Migrations
{
    public partial class Secondcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stockdetails",
                table: "Stockdetails");

            migrationBuilder.RenameTable(
                name: "Stockdetails",
                newName: "StockDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                table: "StockDetails",
                type: "money",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "StockDetails",
                type: "money",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockDetails",
                table: "StockDetails",
                column: "ItemId");

            migrationBuilder.CreateTable(
                name: "sellEntryDetails",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellEntryDetails", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sellEntryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockDetails",
                table: "StockDetails");

            migrationBuilder.RenameTable(
                name: "StockDetails",
                newName: "Stockdetails");

            migrationBuilder.AlterColumn<int>(
                name: "SellingPrice",
                table: "Stockdetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<int>(
                name: "PurchasePrice",
                table: "Stockdetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stockdetails",
                table: "Stockdetails",
                column: "ItemId");
        }
    }
}
