using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reservation_And_Travel_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Email",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Name",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Password",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Surname",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Username",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_State_Name",
                table: "State");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Rol_Name",
                schema: "Identity",
                table: "Rol");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Country_Name",
                table: "Country");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:reservationstatus", "Pending,Completed,Canceled")
                .Annotation("Npgsql:Enum:travelstatus", "Completed,OnGoing,Pending")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                    table.CheckConstraint("CK_Destination_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Destination_Name", "TRIM(\"Name\") <> ''");
                    table.CheckConstraint("CK_Destination_StateId_uuid", "\"StateId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_Destination_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    RegistrationPlate = table.Column<string>(type: "varchar(10)", nullable: false),
                    Model = table.Column<string>(type: "varchar(50)", nullable: false),
                    Capacity = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.CheckConstraint("CK_Vehicle_Capacity_smallint", "\"Capacity\" BETWEEN 1 AND 1000");
                    table.CheckConstraint("CK_Vehicle_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Vehicle_Model_varchar", "TRIM(\"Model\") <> ''");
                    table.CheckConstraint("CK_Vehicle_RegistrationPlate_varchar", "TRIM(\"RegistrationPlate\") <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OriginDestinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    FinalDestinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DistanceInKm = table.Column<decimal>(type: "numeric(10,3)", nullable: false),
                    EstimatedTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uuid", nullable: true),
                    DestinationId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.CheckConstraint("CK_Route_DistanceInKm_numeric", "\"DistanceInKm\" > 0");
                    table.CheckConstraint("CK_Route_EstimatedTime_interval", "\"EstimatedTime\" > interval '1 minute'");
                    table.CheckConstraint("CK_Route_FinalDestinationId_uuid", "\"FinalDestinationId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Route_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Route_OriginDestinationId_uuid", "\"OriginDestinationId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_Route_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Route_Destination_DestinationId1",
                        column: x => x.DestinationId1,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Route_Destination_FinalDestinationId",
                        column: x => x.FinalDestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Route_Destination_OriginDestinationId",
                        column: x => x.OriginDestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "travelstatus", nullable: false, defaultValue: "Pending"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                    table.CheckConstraint("CK_Travel_ArrivalDate_timestamp", "\"ArrivalDate\" > '2023-01-01'::date");
                    table.CheckConstraint("CK_Travel_DepartureDate_timestamp", "\"DepartureDate\" > '2023-01-01'::date");
                    table.CheckConstraint("CK_Travel_DriverId_uuid", "\"DriverId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Travel_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Travel_Price_numeric", "\"Price\" > 0");
                    table.CheckConstraint("CK_Travel_RouteId_uuid", "\"RouteId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Travel_VehicleId_uuid", "\"VehicleId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_Travel_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Travel_User_DriverId",
                        column: x => x.DriverId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Travel_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    TravelId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "reservationstatus", nullable: false, defaultValue: "Pending"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.CheckConstraint("CK_Reservation_ClientId_uuid", "\"ClientId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Reservation_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_Reservation_ReservationDate_timestamp", "\"ReservationDate\" <> '2023-01-01'::date");
                    table.CheckConstraint("CK_Reservation_TravelId_uuid", "\"TravelId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_Reservation_Travel_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservation_User_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ReservationId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetail", x => x.Id);
                    table.CheckConstraint("CK_ReservationDetail_Id_uuid", "\"Id\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_ReservationDetail_ReservationId_uuid", "\"ReservationId\" <> '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_ReservationDetail_SeatNumber_uuid", "\"SeatNumber\" BETWEEN 1 AND 1000");
                    table.ForeignKey(
                        name: "FK_ReservationDetail_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Email",
                schema: "Identity",
                table: "User",
                sql: "TRIM(\"Email\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Name",
                schema: "Identity",
                table: "User",
                sql: "TRIM(\"Name\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Password",
                schema: "Identity",
                table: "User",
                sql: "TRIM(\"Password\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Surname",
                schema: "Identity",
                table: "User",
                sql: "TRIM(\"Surname\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Username",
                schema: "Identity",
                table: "User",
                sql: "TRIM(\"Username\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_State_Name",
                table: "State",
                sql: "TRIM(\"Name\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rol_Name",
                schema: "Identity",
                table: "Rol",
                sql: "TRIM(\"Name\") <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Country_Name",
                table: "Country",
                sql: "TRIM(\"Name\") <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_StateId_Name",
                table: "Destination",
                columns: new[] { "StateId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TravelId",
                table: "Reservation",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetail_ReservationId",
                table: "ReservationDetail",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationId",
                table: "Route",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationId1",
                table: "Route",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Route_FinalDestinationId",
                table: "Route",
                column: "FinalDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_OriginDestinationId_FinalDestinationId",
                table: "Route",
                columns: new[] { "OriginDestinationId", "FinalDestinationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travel_DriverId",
                table: "Travel",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_RouteId",
                table: "Travel",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_VehicleId",
                table: "Travel",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_RegistrationPlate",
                table: "Vehicle",
                column: "RegistrationPlate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationDetail");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Travel");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Email",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Name",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Password",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Surname",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Username",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropCheckConstraint(
                name: "CK_State_Name",
                table: "State");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Rol_Name",
                schema: "Identity",
                table: "Rol");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Country_Name",
                table: "Country");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:reservationstatus", "Pending,Completed,Canceled")
                .OldAnnotation("Npgsql:Enum:travelstatus", "Completed,OnGoing,Pending")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Email",
                schema: "Identity",
                table: "User",
                sql: "\"Email\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Name",
                schema: "Identity",
                table: "User",
                sql: "\"Name\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Password",
                schema: "Identity",
                table: "User",
                sql: "\"Password\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Surname",
                schema: "Identity",
                table: "User",
                sql: "\"Surname\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Username",
                schema: "Identity",
                table: "User",
                sql: "\"Username\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_State_Name",
                table: "State",
                sql: "\"Name\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rol_Name",
                schema: "Identity",
                table: "Rol",
                sql: "\"Name\" <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Country_Name",
                table: "Country",
                sql: "\"Name\" <> ''");
        }
    }
}
