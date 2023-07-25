using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Room_roomId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_roomId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "roomId",
                table: "Appointment");

            migrationBuilder.AddColumn<long>(
                name: "spaId",
                table: "Service",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Service_spaId",
                table: "Service",
                column: "spaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Spa_spaId",
                table: "Service",
                column: "spaId",
                principalTable: "Spa",
                principalColumn: "spaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Spa_spaId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_spaId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "spaId",
                table: "Service");

            migrationBuilder.AddColumn<long>(
                name: "roomId",
                table: "Appointment",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    roomId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spaId = table.Column<long>(type: "bigint", nullable: false),
                    roomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Room_Spa_spaId",
                        column: x => x.spaId,
                        principalTable: "Spa",
                        principalColumn: "spaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_roomId",
                table: "Appointment",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_spaId",
                table: "Room",
                column: "spaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Room_roomId",
                table: "Appointment",
                column: "roomId",
                principalTable: "Room",
                principalColumn: "roomId");
        }
    }
}
