using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All kinds of electronic items", "Electronics" },
                    { 2, "Wide range of books and literature", "Books" },
                    { 3, "Home and office furniture", "Furniture" },
                    { 4, "Fashion and apparel", "Clothing" },
                    { 5, "Sports equipment and accessories", "Sports" },
                    { 6, "Toys for children of all ages", "Toys" },
                    { 7, "Daily grocery and essentials", "Grocery" },
                    { 8, "Beauty and personal care products", "Beauty" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "Ziad123@mail.com", "Ziad", "Fahmy", "123 " },
                    { 2, "Nour123@mail.com", "Nourhan", "Khalil", "123 " },
                    { 3, "Rewan123@mail.com", "Rewan", "Reda", "123 " },
                    { 4, "Morcos123@mail.com", "Morcos", "Osama", "123 " }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "This is Description", "Image_Path", 1234m, 22, " Mouse" },
                    { 2, 2, "This is Description", "Image_Path", 2234m, 11, " Gaming Monitor  " },
                    { 3, 3, "This is Description", "Image_Path", 3234m, 23, " Keyboard  " },
                    { 4, 4, "This is Description", "Image_Path", 4234m, 18, " Gaming Headset" },
                    { 5, 1, "This is Description", "Image_Path", 5234m, 8, " Motherboard " },
                    { 6, 2, "This is Description", "Image_Path", 6234m, 3, " Mouse pad" },
                    { 7, 3, "This is Description", "Image_Path", 7234m, 2, " RAM " },
                    { 8, 4, "This is Description", "Image_Path", 8234m, 5, " Usb driver" },
                    { 9, 1, "This is Description", "Image_Path", 9234m, 6, " Hard disk " },
                    { 10, 2, "This is Description", "Image_Path", 10234m, 4, " SSD " },
                    { 11, 3, "This is Description", "Image_Path", 10234m, 16, " Proccessor " },
                    { 12, 4, "This is Description", "Image_Path", 10234m, 26, " Graphics card " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
