using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Seed15Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8936011110001", 1, 35000m, "Trà Sữa Truyền Thống (Size L)", 120 },
                    { 2, "8936011110002", 1, 35000m, "Trà Sữa Truyền Thống Ít Đường", 95 },
                    { 3, "8936011110003", 3, 42000m, "Trà Đào Cam Sả (Size M)", 80 },
                    { 4, "8936011110004", 2, 45000m, "Trà Sữa Đá Xay Dưa Hấu", 75 },
                    { 5, "8936011110005", 4, 52000m, "Trà Sữa Phô Mai Matcha", 60 },
                    { 6, "8936011110006", 5, 39000m, "Trà Sữa Trân Châu Đường", 140 },
                    { 7, "8936011110007", 6, 38000m, "Trà Ô Long Nhật (Size L)", 110 },
                    { 8, "8936011110008", 7, 30000m, "Trà Sen Nóng", 65 },
                    { 9, "8936011110009", 8, 25000m, "Cà Phê Đen Đá", 200 },
                    { 10, "8936011110010", 8, 30000m, "Bạc Xỉu", 175 },
                    { 11, "8936011110011", 9, 125000m, "Cà Phê Arabica Đắk Lắk 100g", 40 },
                    { 12, "8936011110012", 10, 28000m, "Nước Cam Ép Tươi 500ml", 90 },
                    { 13, "8936011110013", 11, 32000m, "Sữa Tươi UHT 1L", 130 },
                    { 14, "8936011110014", 12, 22000m, "Bánh Mì Chà Nướng", 70 },
                    { 15, "8936011110015", 13, 30000m, "Bánh Mì Trứng Ống Laflin", 85 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);
        }
    }
}
