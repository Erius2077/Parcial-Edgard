using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasteleria.Migrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingStatus_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    BookingId1 = table.Column<int>(type: "int", nullable: true),
                    BookingId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Booking_BookingId1",
                        column: x => x.BookingId1,
                        principalTable: "Booking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Booking_BookingId2",
                        column: x => x.BookingId2,
                        principalTable: "Booking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    BookingId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Treatment_Booking_BookingId1",
                        column: x => x.BookingId1,
                        principalTable: "Booking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentTime_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_BookingId",
                table: "User",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ScheduleId",
                table: "User",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingStatus_BookingId",
                table: "BookingStatus",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_BookingId",
                table: "Schedule",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_BookingId1",
                table: "Schedule",
                column: "BookingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_BookingId2",
                table: "Schedule",
                column: "BookingId2");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_BookingId",
                table: "Treatment",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_BookingId1",
                table: "Treatment",
                column: "BookingId1");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentTime_ScheduleId",
                table: "TreatmentTime",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Booking_BookingId",
                table: "User",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Schedule_ScheduleId",
                table: "User",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Booking_BookingId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Schedule_ScheduleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "TreatmentTime");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_User_BookingId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ScheduleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "User");
        }
    }
}