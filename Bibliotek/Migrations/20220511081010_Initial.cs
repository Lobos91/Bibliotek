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
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: true),
                    Lent = table.Column<bool>(type: "bit", nullable: false),
                    LoanDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ebooks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: true),
                    Lent = table.Column<bool>(type: "bit", nullable: false),
                    LoanDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ebooks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ebooks_Users_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lengthmin = table.Column<int>(name: "Length(min)", type: "int", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lent = table.Column<bool>(type: "bit", nullable: false),
                    LoanDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movies_Users_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Genre", "Lent", "LoanDateTimeEnd", "LoanDateTimeStart", "Pages", "Tittle", "UserModelID" },
                values: new object[,]
                {
                    { 1, "David Willcock", "Document", false, null, null, 437, "Secret of the universe", null },
                    { 2, "Mariam Jasmin", "Poetry", false, null, null, 301, "Cool book", null },
                    { 3, "Arnold S.", "Manual", true, new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 301, "Training techniques", null }
                });

            migrationBuilder.InsertData(
                table: "Ebooks",
                columns: new[] { "ID", "Author", "Genre", "Lent", "LoanDateTimeEnd", "LoanDateTimeStart", "Pages", "Tittle", "UserModelID" },
                values: new object[] { 6, "Tom Hardy", "Manual", false, null, null, 264, "C# for begginers", null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Director", "Genre", "Length(min)", "Lent", "LoanDateTimeEnd", "LoanDateTimeStart", "Tittle", "UserModelID" },
                values: new object[,]
                {
                    { 4, "Wachowsky brothers", "Document", 94, false, null, null, "Matrix", null },
                    { 5, "Wachowsky brothers", "SF", 142, true, new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cloud Atlas", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserModelID",
                table: "Books",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Ebooks_UserModelID",
                table: "Ebooks",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserModelID",
                table: "Movies",
                column: "UserModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Ebooks");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
