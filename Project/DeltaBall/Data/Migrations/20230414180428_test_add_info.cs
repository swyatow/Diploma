using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeltaBall.Data.Migrations
{
    /// <inheritdoc />
    public partial class test_add_info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0531adfe-8fad-4e95-8d59-0b2294b982fc", null, "Admin", "ADMIN" },
                    { "514087fb-c72f-4712-b1e1-a3128e44e478", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "41dd2d65-6650-4cce-b3fd-dead95a3ee7a", 0, "e4bd5fff-4956-4a0f-937b-3ca70e63d22d", "ivanov_delta@gmail.com", true, false, null, "IVANOV_DELTA@GMAIL.COM", "ИВАНОВ ИВАН ИВАНОВИЧ", "AQAAAAIAAYagAAAAEB28OQLcebHOGhUd+TQ1fWN9t9xofDE2AmVQmxwCYb0nGZB+U3XZ+cYt3mzMD/nHjQ==", "8(123)456-78-90", true, "5f4c30ac-ce7a-4684-b7bc-ce794bfe80ab", false, "Иванов Иван Иванович" },
                    { "ce301bc6-b3f6-4ff7-b425-bd4777a1e9ac", 0, "e4a7c51c-4010-475f-97e3-8b256ecaf6c0", "slavanovosyolov@gmail.com", true, false, null, "SLAVANOVOSYOLOV@GMAIL.COM", "НОВОСЕЛОВ СВЯТОСЛАВ ДМИТРИЕВИЧ", "AQAAAAIAAYagAAAAEFLZ3Sm3UYEJuo8z1s4NzFzQ0rO3lf3Alwdaswj8p+Q24lFsT1dm9nyskGm2OLdGQA==", "8(123)456-78-91", true, "b4b0eae7-847e-497a-bc93-f3362cc2578a", false, "Новоселов Святослав Дмитриевич" }
                });

            migrationBuilder.UpdateData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "ImagePath", "MaxExp", "MinExp", "Name" },
                values: new object[] { 1, "~/Images/Ranks/bronze.png", 100, 0, "Бронза" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "Experience", "FullName", "PhoneNumber", "RankId" },
                values: new object[] { new Guid("ce8681a1-a903-42b2-b181-df7502bf9dfd"), "slavanovosyolov@gmail.com", 0, "Новоселов Святослав Дмитриевич", "8(123)456-78-91", 1 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0531adfe-8fad-4e95-8d59-0b2294b982fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "514087fb-c72f-4712-b1e1-a3128e44e478");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41dd2d65-6650-4cce-b3fd-dead95a3ee7a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce301bc6-b3f6-4ff7-b425-bd4777a1e9ac");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("ce8681a1-a903-42b2-b181-df7502bf9dfd"));

            migrationBuilder.UpdateData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "ImagePath", "MaxExp", "MinExp", "Name" },
                values: new object[] { 2, "~/Images/Ranks/default.png", 40, 30, "Тестовое звание" });
        }
    }
}
