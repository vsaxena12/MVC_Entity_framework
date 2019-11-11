using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo_MVC.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaveTypeClass",
                columns: table => new
                {
                    LeaveTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveTypeClass", x => x.LeaveTypeID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "leaves",
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
                    table.PrimaryKey("PK_leaves", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_leaves_leaveTypeClass_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "leaveTypeClass",
                        principalColumn: "LeaveTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaves_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaves_LeaveTypeID",
                table: "leaves",
                column: "LeaveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_leaves_UserID",
                table: "leaves",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaves");

            migrationBuilder.DropTable(
                name: "leaveTypeClass");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
