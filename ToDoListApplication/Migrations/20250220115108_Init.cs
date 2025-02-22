using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListApplication.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "Mansoura", "Loai@yaho", "Loai", "123456", "0501255623" },
                    { 2, "Mansoura", "Menna@yaho", "Menna", "147258", "05012s55623" }
                });

            migrationBuilder.InsertData(
                table: "MyLists",
                columns: new[] { "Id", "Deadline", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 25, 13, 51, 7, 34, DateTimeKind.Local).AddTicks(6704), "Study HTML Study HTML Study HTML ", "Study HTML", 1 },
                    { 2, new DateTime(2025, 3, 2, 18, 51, 7, 34, DateTimeKind.Local).AddTicks(6789), "Study CSS Study CSS Study CSS ", "Study CSS", 2 },
                    { 3, new DateTime(2025, 3, 8, 5, 51, 7, 34, DateTimeKind.Local).AddTicks(6792), "Study JS Study JS Study JS", "Study JS", 1 },
                    { 4, new DateTime(2025, 3, 18, 0, 51, 7, 34, DateTimeKind.Local).AddTicks(6848), "Study MVC Study MVC Study MVC", "Study MVC", 2 },
                    { 5, new DateTime(2025, 3, 18, 0, 51, 7, 34, DateTimeKind.Local).AddTicks(6851), "Study LINQ Study LINQ Study LINQ", "Study LINQ", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyLists_UserId",
                table: "MyLists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
