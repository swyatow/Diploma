using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeltaBall.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_GameScenarios_GameScenarioId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_GameScenarioId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "GameScenarioId",
                table: "Prices");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41dd2d65-6650-4cce-b3fd-dead95a3ee7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8205431a-52b3-4376-8b23-edad3d008eff", "AQAAAAIAAYagAAAAEAvD0lOvuVrNGA2jRrbNVO0o9X3EAK5qcGXSRpx3yPkqGAuU356mrPeD8lCsme78AQ==", "78420da6-610f-409c-90bf-be773ae34341" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce301bc6-b3f6-4ff7-b425-bd4777a1e9ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c91b08ea-7c19-4593-8ea9-f82cf0702127", "AQAAAAIAAYagAAAAEGcYNu76QzkhBoQsWCQ+i4jxUMP4GH8k6Q5hvXDmilv3RkUTFRbycN/dkEm5rCyHKA==", "5cd87cdc-07c3-498c-92cf-6a8d2f64a230" });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ScenarioId",
                table: "Prices",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_GameScenarios_ScenarioId",
                table: "Prices",
                column: "ScenarioId",
                principalTable: "GameScenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_GameScenarios_ScenarioId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ScenarioId",
                table: "Prices");

            migrationBuilder.AddColumn<int>(
                name: "GameScenarioId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41dd2d65-6650-4cce-b3fd-dead95a3ee7a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4bd5fff-4956-4a0f-937b-3ca70e63d22d", "AQAAAAIAAYagAAAAEB28OQLcebHOGhUd+TQ1fWN9t9xofDE2AmVQmxwCYb0nGZB+U3XZ+cYt3mzMD/nHjQ==", "5f4c30ac-ce7a-4684-b7bc-ce794bfe80ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce301bc6-b3f6-4ff7-b425-bd4777a1e9ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4a7c51c-4010-475f-97e3-8b256ecaf6c0", "AQAAAAIAAYagAAAAEFLZ3Sm3UYEJuo8z1s4NzFzQ0rO3lf3Alwdaswj8p+Q24lFsT1dm9nyskGm2OLdGQA==", "b4b0eae7-847e-497a-bc93-f3362cc2578a" });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_GameScenarioId",
                table: "Prices",
                column: "GameScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_GameScenarios_GameScenarioId",
                table: "Prices",
                column: "GameScenarioId",
                principalTable: "GameScenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
