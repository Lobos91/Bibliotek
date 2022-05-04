using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotek.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
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
                name: "EBookModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lent = table.Column<bool>(type: "bit", nullable: false),
                    LoanDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EBookModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EBookModel_Users_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MovieModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lent = table.Column<bool>(type: "bit", nullable: false),
                    LoanDateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanDateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieModel_Users_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserModelID",
                table: "Books",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EBookModel_UserModelID",
                table: "EBookModel",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieModel_UserModelID",
                table: "MovieModel",
                column: "UserModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "EBookModel");

            migrationBuilder.DropTable(
                name: "MovieModel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
