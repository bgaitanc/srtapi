using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class State_Table_And_Delete_Behavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_Rol_RolId",
                schema: "Identity",
                table: "UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_User_UserId",
                schema: "Identity",
                table: "UserRol");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.CheckConstraint("CK_State_CountryId_uuid", "\"CountryId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_State_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_State_Name", "\"Name\" <> ''");
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId_Name",
                table: "State",
                columns: new[] { "CountryId", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_Rol_RolId",
                schema: "Identity",
                table: "UserRol",
                column: "RolId",
                principalSchema: "Identity",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_User_UserId",
                schema: "Identity",
                table: "UserRol",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_Rol_RolId",
                schema: "Identity",
                table: "UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_User_UserId",
                schema: "Identity",
                table: "UserRol");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_Rol_RolId",
                schema: "Identity",
                table: "UserRol",
                column: "RolId",
                principalSchema: "Identity",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_User_UserId",
                schema: "Identity",
                table: "UserRol",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
