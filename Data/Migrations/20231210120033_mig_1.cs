using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 10, 15, 0, 32, 654, DateTimeKind.Local).AddTicks(7801), "Bilim", null },
                    { 2, new DateTime(2023, 12, 10, 15, 0, 32, 654, DateTimeKind.Local).AddTicks(7804), "Yazılım", null },
                    { 3, new DateTime(2023, 12, 10, 15, 0, 32, 654, DateTimeKind.Local).AddTicks(7805), "Teknoloji", null },
                    { 4, new DateTime(2023, 12, 10, 15, 0, 32, 654, DateTimeKind.Local).AddTicks(7805), "Sağlık", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "PasswordHash", "PasswordSalt", "Role", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 10, 15, 0, 32, 654, DateTimeKind.Local).AddTicks(7783), "admin@mail.com", new byte[] { 250, 46, 75, 121, 210, 151, 206, 155, 63, 88, 235, 249, 236, 74, 185, 112, 18, 137, 229, 221, 47, 37, 248, 130, 248, 154, 2, 126, 65, 120, 52, 21, 192, 183, 192, 155, 138, 124, 31, 6, 176, 151, 91, 147, 199, 17, 62, 45, 123, 63, 81, 65, 208, 213, 53, 93, 250, 160, 135, 103, 238, 205, 44, 187 }, new byte[] { 167, 139, 49, 206, 118, 146, 154, 15, 207, 126, 155, 240, 67, 117, 26, 39, 6, 186, 23, 176, 171, 63, 107, 59, 50, 79, 158, 85, 246, 66, 134, 222, 243, 253, 133, 246, 111, 195, 65, 233, 251, 136, 88, 79, 115, 108, 38, 26, 164, 188, 251, 24, 118, 210, 136, 132, 236, 132, 56, 227, 253, 65, 233, 179, 223, 252, 155, 212, 119, 167, 6, 209, 191, 244, 65, 166, 180, 169, 58, 199, 126, 96, 170, 245, 244, 13, 0, 196, 104, 132, 248, 29, 34, 49, 32, 84, 140, 87, 185, 55, 157, 174, 217, 154, 155, 99, 9, 135, 189, 204, 23, 242, 180, 182, 214, 81, 34, 94, 153, 178, 191, 109, 242, 104, 44, 242, 175, 230 }, "Admin", null, "admin" },
                    { 2, new DateTime(2023, 12, 10, 15, 0, 32, 654, DateTimeKind.Local).AddTicks(7798), "kemal@mail.com", new byte[] { 250, 46, 75, 121, 210, 151, 206, 155, 63, 88, 235, 249, 236, 74, 185, 112, 18, 137, 229, 221, 47, 37, 248, 130, 248, 154, 2, 126, 65, 120, 52, 21, 192, 183, 192, 155, 138, 124, 31, 6, 176, 151, 91, 147, 199, 17, 62, 45, 123, 63, 81, 65, 208, 213, 53, 93, 250, 160, 135, 103, 238, 205, 44, 187 }, new byte[] { 167, 139, 49, 206, 118, 146, 154, 15, 207, 126, 155, 240, 67, 117, 26, 39, 6, 186, 23, 176, 171, 63, 107, 59, 50, 79, 158, 85, 246, 66, 134, 222, 243, 253, 133, 246, 111, 195, 65, 233, 251, 136, 88, 79, 115, 108, 38, 26, 164, 188, 251, 24, 118, 210, 136, 132, 236, 132, 56, 227, 253, 65, 233, 179, 223, 252, 155, 212, 119, 167, 6, 209, 191, 244, 65, 166, 180, 169, 58, 199, 126, 96, 170, 245, 244, 13, 0, 196, 104, 132, 248, 29, 34, 49, 32, 84, 140, 87, 185, 55, 157, 174, 217, 154, 155, 99, 9, 135, 189, 204, 23, 242, 180, 182, 214, 81, 34, 94, 153, 178, 191, 109, 242, 104, 44, 242, 175, 230 }, "Reader", null, "kemal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
