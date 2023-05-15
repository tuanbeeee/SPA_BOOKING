using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class FirstDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.accountId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    serviceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    servicePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.serviceId);
                });

            migrationBuilder.CreateTable(
                name: "Spa",
                columns: table => new
                {
                    spaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spaAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spaPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spaEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spa", x => x.spaId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customer_Account_accountId",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    discountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discountCode = table.Column<long>(type: "bigint", nullable: false),
                    discountType = table.Column<int>(type: "int", nullable: false),
                    discountAmount = table.Column<double>(type: "float", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    service_IdserviceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.discountId);
                    table.ForeignKey(
                        name: "FK_Discount_Service_service_IdserviceId",
                        column: x => x.service_IdserviceId,
                        principalTable: "Service",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    roomId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomStatus = table.Column<int>(type: "int", nullable: false),
                    spa_IdspaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Room_Spa_spa_IdspaId",
                        column: x => x.spa_IdspaId,
                        principalTable: "Spa",
                        principalColumn: "spaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staffId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spa_IdspaId = table.Column<long>(type: "bigint", nullable: false),
                    accountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staffId);
                    table.ForeignKey(
                        name: "FK_Staff_Account_accountId",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Spa_spa_IdspaId",
                        column: x => x.spa_IdspaId,
                        principalTable: "Spa",
                        principalColumn: "spaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    appointmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_IdcustomerId = table.Column<long>(type: "bigint", nullable: true),
                    staff_IdstaffId = table.Column<long>(type: "bigint", nullable: true),
                    room_IdroomId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.appointmentId);
                    table.ForeignKey(
                        name: "FK_Appointment_Customer_customer_IdcustomerId",
                        column: x => x.customer_IdcustomerId,
                        principalTable: "Customer",
                        principalColumn: "customerId");
                    table.ForeignKey(
                        name: "FK_Appointment_Room_room_IdroomId",
                        column: x => x.room_IdroomId,
                        principalTable: "Room",
                        principalColumn: "roomId");
                    table.ForeignKey(
                        name: "FK_Appointment_Staff_staff_IdstaffId",
                        column: x => x.staff_IdstaffId,
                        principalTable: "Staff",
                        principalColumn: "staffId");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    reviewId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewRate = table.Column<int>(type: "int", nullable: false),
                    reviewContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_IdcustomerId = table.Column<long>(type: "bigint", nullable: false),
                    staff_IdstaffId = table.Column<long>(type: "bigint", nullable: false),
                    service_IdserviceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_Review_Customer_customer_IdcustomerId",
                        column: x => x.customer_IdcustomerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Service_service_IdserviceId",
                        column: x => x.service_IdserviceId,
                        principalTable: "Service",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Staff_staff_IdstaffId",
                        column: x => x.staff_IdstaffId,
                        principalTable: "Staff",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetail",
                columns: table => new
                {
                    appointmentDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_IdappointmentId = table.Column<long>(type: "bigint", nullable: false),
                    service_IdserviceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetail", x => x.appointmentDetailId);
                    table.ForeignKey(
                        name: "FK_AppointmentDetail_Appointment_appointment_IdappointmentId",
                        column: x => x.appointment_IdappointmentId,
                        principalTable: "Appointment",
                        principalColumn: "appointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetail_Service_service_IdserviceId",
                        column: x => x.service_IdserviceId,
                        principalTable: "Service",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentAmount = table.Column<double>(type: "float", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appointmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Appointment_appointmentId",
                        column: x => x.appointmentId,
                        principalTable: "Appointment",
                        principalColumn: "appointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_customer_IdcustomerId",
                table: "Appointment",
                column: "customer_IdcustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_room_IdroomId",
                table: "Appointment",
                column: "room_IdroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_staff_IdstaffId",
                table: "Appointment",
                column: "staff_IdstaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetail_appointment_IdappointmentId",
                table: "AppointmentDetail",
                column: "appointment_IdappointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetail_service_IdserviceId",
                table: "AppointmentDetail",
                column: "service_IdserviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_accountId",
                table: "Customer",
                column: "accountId",
                unique: true,
                filter: "[accountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_service_IdserviceId",
                table: "Discount",
                column: "service_IdserviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_appointmentId",
                table: "Payment",
                column: "appointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_customer_IdcustomerId",
                table: "Review",
                column: "customer_IdcustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_service_IdserviceId",
                table: "Review",
                column: "service_IdserviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_staff_IdstaffId",
                table: "Review",
                column: "staff_IdstaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_spa_IdspaId",
                table: "Room",
                column: "spa_IdspaId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_accountId",
                table: "Staff",
                column: "accountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_spa_IdspaId",
                table: "Staff",
                column: "spa_IdspaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetail");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Spa");
        }
    }
}
