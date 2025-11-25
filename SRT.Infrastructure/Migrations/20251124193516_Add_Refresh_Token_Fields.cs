using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Refresh_Token_Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "Identity",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                schema: "Identity",
                table: "User",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                schema: "Identity",
                table: "User");
        }
    }
}
