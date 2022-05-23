using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotek.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseId = table.Column<int>(type: "int", nullable: false),
                    BookFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeMb = table.Column<double>(name: "Size(Mb)", type: "float", nullable: true),
                    Lengthmin = table.Column<int>(name: "Length(min)", type: "int", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lent = table.Column<bool>(type: "bit", nullable: false),
                    LoanDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Releases",
                columns: new[] { "Id", "Author", "Genre", "Pages", "Title" },
                values: new object[,]
                {
                    { 1, "J. K. Rowling", "Fantasy", 503, "Harry Potter" },
                    { 2, "J. K. Rowling", "Fantasy", 582, "Harry Potter 2.0" },
                    { 3, "Albin Svensson", "Course", 900, "C# for noobs" },
                    { 4, "Albin Svensson", "Course", 1402, "C# for noobs extended" },
                    { 5, "Wachowsky brothers", "SF", null, "Matrix" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Marius Ohlsson" },
                    { 2, 0, "Jesus Christus" },
                    { 3, 0, "Sasha Grey" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BookFormat", "Lent", "LoanDateTimeEnd", "LoanDateTimeStart", "ReleaseId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, "A2", false, null, null, 1, "Book", null },
                    { 2, "A2", true, new DateTime(2022, 5, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Book", 1 },
                    { 3, "A2", false, null, null, 2, "Book", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Size(Mb)", "Lent", "LoanDateTimeEnd", "LoanDateTimeStart", "ReleaseId", "Type", "UserId" },
                values: new object[,]
                {
                    { 4, 0.59999999999999998, false, null, null, 3, "Ebook", null },
                    { 5, 2.2999999999999998, true, new DateTime(2022, 5, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ebook", 1 },
                    { 6, 1.2, true, new DateTime(2022, 5, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ebook", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Director", "Length(min)", "Lent", "LoanDateTimeEnd", "LoanDateTimeStart", "ReleaseId", "Type", "UserId" },
                values: new object[,]
                {
                    { 7, "Wachowsky brothers", 94, false, null, null, 5, "Movie", null },
                    { 8, "Wachowsky brothers", 94, false, null, null, 5, "Movie", null },
                    { 9, "Wachowsky brothers", 94, true, new DateTime(2022, 5, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 5, "Movie", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReleaseId",
                table: "Products",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
