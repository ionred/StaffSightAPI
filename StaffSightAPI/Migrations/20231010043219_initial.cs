using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffSightAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilletsPreHires",
                columns: table => new
                {
                    BilletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BilletNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilletsPreHires", x => x.BilletID);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePreHires",
                columns: table => new
                {
                    EmpID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    AddressFirst = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    AddressSecond = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    City = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    State = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Zip = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BilletNumber = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    ExpectedHireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsContractor = table.Column<bool>(type: "bit", nullable: true),
                    IsConversion = table.Column<bool>(type: "bit", nullable: true),
                    AssignedTA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePreHires", x => x.EmpID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BilletsPreHires");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "EmployeePreHires");
        }
    }
}
