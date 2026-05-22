using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_Id);
                });

            migrationBuilder.CreateTable(
                name: "Librarian",
                columns: table => new
                {
                    user_Id = table.Column<int>(type: "int", nullable: false),
                    hiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shift = table.Column<string>(type: "nvarchar(2100)", maxLength: 2100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarian", x => x.user_Id);
                    table.ForeignKey(
                        name: "FK_Librarian_Users_user_Id",
                        column: x => x.user_Id,
                        principalTable: "Users",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    user_Id = table.Column<int>(type: "int", nullable: false),
                    officeLocatiom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.user_Id);
                    table.ForeignKey(
                        name: "FK_Manager_Users_user_Id",
                        column: x => x.user_Id,
                        principalTable: "Users",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    user_Id = table.Column<int>(type: "int", nullable: false),
                    membership_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    borrow_limit = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.user_Id);
                    table.ForeignKey(
                        name: "FK_Member_Users_user_Id",
                        column: x => x.user_Id,
                        principalTable: "Users",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Librarian");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
