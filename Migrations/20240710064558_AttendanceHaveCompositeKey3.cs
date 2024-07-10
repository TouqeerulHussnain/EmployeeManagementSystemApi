using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceHaveCompositeKey3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Attendances_Date_EmployeeId",
                table: "Attendances",
                columns: new[] { "Date", "EmployeeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendances_Date_EmployeeId",
                table: "Attendances");
        }
    }
}
