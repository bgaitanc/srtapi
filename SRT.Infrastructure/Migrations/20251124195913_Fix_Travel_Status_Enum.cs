using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Travel_Status_Enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:reservationstatus", "Pending,Completed,Canceled")
                .Annotation("Npgsql:Enum:travelstatus", "Pending,OnGoing,Completed")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:reservationstatus", "Pending,Completed,Canceled")
                .OldAnnotation("Npgsql:Enum:travelstatus", "Completed,OnGoing,Pending")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:reservationstatus", "Pending,Completed,Canceled")
                .Annotation("Npgsql:Enum:travelstatus", "Completed,OnGoing,Pending")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:reservationstatus", "Pending,Completed,Canceled")
                .OldAnnotation("Npgsql:Enum:travelstatus", "Pending,OnGoing,Completed")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }
    }
}
