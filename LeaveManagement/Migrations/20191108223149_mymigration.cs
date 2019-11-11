using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class mymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leave",
                columns: table => new
                {
                    LeaveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    LeaveTypeID = table.Column<int>(nullable: false),
                    Noofdays = table.Column<int>(nullable: false),
                    LeaveReason = table.Column<string>(nullable: false),
                    LeaveStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave", x => x.LeaveID);
                });

            migrationBuilder.CreateTable(
                name: "leaveTypeClass",
                columns: table => new
                {
                    LeaveTypeID = table.Column<int>(nullable: false),
                    LeaveType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveTypeClass", x => x.LeaveTypeID);
                    table.ForeignKey(
                        name: "FK_leaveTypeClass_leave_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "leave",
                        principalColumn: "LeaveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_user_leave_UserID",
                        column: x => x.UserID,
                        principalTable: "leave",
                        principalColumn: "LeaveID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveTypeClass");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "leave");
        }
    }
}
