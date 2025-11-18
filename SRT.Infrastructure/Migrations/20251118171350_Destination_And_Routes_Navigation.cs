using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Destination_And_Routes_Navigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Destination_DestinationId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Destination_DestinationId1",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_DestinationId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_DestinationId1",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Route");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "Route",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId1",
                table: "Route",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationId",
                table: "Route",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationId1",
                table: "Route",
                column: "DestinationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Destination_DestinationId",
                table: "Route",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Destination_DestinationId1",
                table: "Route",
                column: "DestinationId1",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
