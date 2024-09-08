using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personel.EFCore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitPersonelDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK_Workers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelDetails",
                columns: table => new
                {
                    PersonelDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelDetails", x => x.PersonelDetailID);
                    table.ForeignKey(
                        name: "FK_PersonelDetails_Workers_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Workers",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonelDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_PersonelDetails_PersonelDetailID",
                        column: x => x.PersonelDetailID,
                        principalTable: "PersonelDetails",
                        principalColumn: "PersonelDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Yazılım" },
                    { 2, "İnsan Kaynakları" },
                    { 3, "Yazar" },
                    { 4, "Pazarlamacı" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderID", "GenderName", "State" },
                values: new object[,]
                {
                    { 1, "Erkek", false },
                    { 2, "Kadın", false }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "PersonelID", "BirthDate", "DepartmentID", "FirstName", "GenderID", "IdentityNumber", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ali", 1, "12345678901", "Kılıç" },
                    { 2, new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ayşe", 2, "12345678902", "Yılmaz" },
                    { 3, new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ahmet", 1, "12345678903", "Demir" },
                    { 4, new DateTime(1988, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Fatma", 2, "12345678904", "Öztürk" },
                    { 5, new DateTime(1983, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mehmet", 1, "12345678905", "Ak" }
                });

            migrationBuilder.InsertData(
                table: "PersonelDetails",
                columns: new[] { "PersonelDetailID", "Email", "PersonelID", "Phone" },
                values: new object[,]
                {
                    { 1, "ali.kilic@example.com", 1, "555-1234" },
                    { 2, "ayse.yilmaz@example.com", 2, "555-5678" },
                    { 3, "ahmet.demir@example.com", 3, "555-9101" },
                    { 4, "fatma.ozturk@example.com", 4, "555-1122" },
                    { 5, "mehmet.ak@example.com", 5, "555-1314" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "Country", "PersonelDetailID", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, "Istanbul", "Turkey", 1, "34000", "Marmara" },
                    { 2, "Ankara", "Turkey", 2, "06000", "Anadolu" },
                    { 3, "Izmir", "Turkey", 3, "35000", "Ege" },
                    { 4, "Antalya", "Turkey", 4, "07000", "Akdeniz" },
                    { 5, "Bursa", "Turkey", 5, "16000", "Marmara" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonelDetailID",
                table: "Addresses",
                column: "PersonelDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDetails_PersonelID",
                table: "PersonelDetails",
                column: "PersonelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentID",
                table: "Workers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_GenderID",
                table: "Workers",
                column: "GenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PersonelDetails");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
