using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCompute.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class PaymentRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OverTimeHours",
                table: "PaymentRecords",
                newName: "OvertimeHours");

            migrationBuilder.RenameColumn(
                name: "OverTimeEarnings",
                table: "PaymentRecords",
                newName: "OvertimeEarnings");

            migrationBuilder.AddColumn<decimal>(
                name: "ContractualEarnings",
                table: "PaymentRecords",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractualEarnings",
                table: "PaymentRecords");

            migrationBuilder.RenameColumn(
                name: "OvertimeHours",
                table: "PaymentRecords",
                newName: "OverTimeHours");

            migrationBuilder.RenameColumn(
                name: "OvertimeEarnings",
                table: "PaymentRecords",
                newName: "OverTimeEarnings");
        }
    }
}
