using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleInsuranceClaimMSAPIConnect.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance_Companies",
                columns: table => new
                {
                    Company_Identification_No = table.Column<int>(nullable: false),
                    Company_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Company_Contact = table.Column<string>(maxLength: 50, nullable: false),
                    Company_Address = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance_Companies", x => x.Company_Identification_No);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false),
                    User_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Email_ID = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Mobile_Number = table.Column<string>(maxLength: 10, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    Pin_Code = table.Column<string>(maxLength: 50, nullable: false),
                    No_Of_Claims = table.Column<int>(nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Vehicle_No = table.Column<int>(nullable: false),
                    Vehicle_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Type = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_ModelMaker = table.Column<string>(name: "Vehicle_Model/Maker", maxLength: 50, nullable: true),
                    Gross_Vehicle_Weight = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Power = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Capacity = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Length = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Owner = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Engine_No = table.Column<string>(maxLength: 50, nullable: true),
                    Fuel_Type = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Company = table.Column<string>(maxLength: 50, nullable: true),
                    Owner_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Vehicle_No);
                    table.ForeignKey(
                        name: "fk_vehicle",
                        column: x => x.Owner_Id,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Policy_Id = table.Column<int>(nullable: false),
                    Vehicle_Id = table.Column<int>(nullable: false),
                    Policy_Name = table.Column<string>(maxLength: 10, nullable: false),
                    Effective_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Expiry_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Policy_Id);
                    table.ForeignKey(
                        name: "fk_policy",
                        column: x => x.Vehicle_Id,
                        principalTable: "Vehicles",
                        principalColumn: "Vehicle_No",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Claim_Id = table.Column<int>(nullable: false),
                    Policy_Id = table.Column<int>(nullable: false),
                    Vehicle_Bill = table.Column<string>(maxLength: 50, nullable: true),
                    Driver_Licence_No = table.Column<string>(maxLength: 50, nullable: true),
                    Vehicle_Condition = table.Column<string>(maxLength: 50, nullable: true),
                    Claim_Status = table.Column<string>(maxLength: 50, nullable: true),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Claim_Id);
                    table.ForeignKey(
                        name: "Fk_policyid",
                        column: x => x.Policy_Id,
                        principalTable: "Policy",
                        principalColumn: "Policy_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_user",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_Policy_Id",
                table: "Claims",
                column: "Policy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_User_Id",
                table: "Claims",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_Vehicle_Id",
                table: "Policy",
                column: "Vehicle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Owner_Id",
                table: "Vehicles",
                column: "Owner_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Insurance_Companies");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
