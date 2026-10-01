using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Seed15CategoriesAndCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Trà Sữa Phô Mai", "Trà sữa phô mai, cheese foam, kem cheese" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Trà Sữa Trân Châu", "Trân châu đường, trân châu trắng, trân châu tuyết" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Trà Ô Long", "Trà ô long nhật, trà ô long sữa, đen đá" },
                    { 7, "Trà Lài & Trà Sen", "Trà lài, trà sen, trà lài sen" },
                    { 8, "Cà Phê", "Cà phê đen, bạc xỉu, cà phê sữa đá" },
                    { 9, "Cà Phê Đặc Sản", "Cà phê robusta Tây Nguyên, arabica Đắk Lắk" },
                    { 10, "Nước Ép Trái Cây", "Nước cam, nước dứa, nước ổi, nước xoài" },
                    { 11, "Sữa Tươi & Sữa Chua", "Sữa tươi, sữa chua uống, sữa đậm" },
                    { 12, "Bánh Ngọt", "Bánh mì chà, bánh chuối, bánh bông lan" },
                    { 13, "Bánh Mì & Bánh Tráng Miệng", "Bánh mì trứng, bánh mì xúc xích, bánh tráng" },
                    { 14, "Đồ Ăn Vặt", "Snack, bánh quy, kẹo, trái cây khô" },
                    { 15, "Trà Nóng & Đồ Uống Khác", "Trà nóng, nước khoáng, nước có ga, sữa chua uống" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerName", "RewardPoints" },
                values: new object[] { "Nguyễn Văn An", 1520 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerName", "RewardPoints" },
                values: new object[] { "Trần Thị Bích", 860 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CustomerName", "RewardPoints" },
                values: new object[] { "Lê Văn Chiến", 340 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 4, "15 Lý Thường Kiệt, Q.1, TP.HCM", "Phạm Thị Dung", "Kim Cương", "0935566778", 3200 },
                    { 5, "200 Trần Hưng Đạo, Q.5, TP.HCM", "Hoàng Minh Đức", "Vàng", "0909988776", 1450 },
                    { 6, "36 Nguyễn Văn Trỗi, Phú Nhuận, TP.HCM", "Võ Thị Giang", "Chuẩn", "0911223344", 125 },
                    { 7, "88 Cách Mạng Tháng 8, Q.10, TP.HCM", "Đặng Quốc Huy", "Bạc", "0967445566", 720 },
                    { 8, "5 Phạm Ngũ Lão, Q.5, TP.HCM", "Bùi Khánh Linh", "Kim Cương", "0972334455", 2850 },
                    { 9, "120 Pasteur, Q.3, TP.HCM", "Đỗ Anh Tuấn", "Chuẩn", "0905667788", 60 },
                    { 10, "72 Lê Văn Sỹ, Q.3, TP.HCM", "Ngô Thị Mai", "Bạc", "0948112233", 940 },
                    { 11, "250 Điện Biên Phủ, Q.7, TP.HCM", "Trịnh Bảo Ngọc", "Vàng", "0933445566", 1680 },
                    { 12, "9 Nguyễn Thị Minh Khai, Q.1, TP.HCM", "Ngô Minh Quân", "Chuẩn", "0966778899", 15 },
                    { 13, "310 Cách Mạng Tháng 8, Q.10, TP.HCM", "Lý Hoàng Phong", "Bạc", "0975556677", 610 },
                    { 14, "17 Trần Phú, Q.5, TP.HCM", "Phan Ngọc Oanh", "Kim Cương", "0988223344", 4100 },
                    { 15, "64 Nguyễn Đình Chiểu, Q.3, TP.HCM", "Vũ Đình Phúc", "Chuẩn", "0901445566", 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Bánh Ngọt & Ăn Vặt", "Bánh mì chà, bánh ngọt, đồ ăn vặt" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Cà Phê & Đồ Uống Khác", "Cà phê, nước ép, trà nóng" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerName", "RewardPoints" },
                values: new object[] { "Nguyễn Văn A", 150 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerName", "RewardPoints" },
                values: new object[] { "Trần Thị B", 50 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CustomerName", "RewardPoints" },
                values: new object[] { "Lê Văn C", 10 });
        }
    }
}
