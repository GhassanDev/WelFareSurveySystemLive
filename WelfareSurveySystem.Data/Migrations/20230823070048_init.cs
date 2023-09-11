using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WelfareSurveySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "PersonSequence");

            migrationBuilder.CreateSequence(
                name: "WelfareFormSequence");

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Village = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTypes",
                columns: table => new
                {
                    RealEstateTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealEstateTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTypes", x => x.RealEstateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaskRequests",
                columns: table => new
                {
                    TaskRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromServiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WelfareFormId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRequests", x => x.TaskRequestID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCard = table.Column<int>(type: "int", nullable: false),
                    ServiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ShekhName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeceased = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresss",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    TaskStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskRequestID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedByServiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.TaskStatusID);
                    table.ForeignKey(
                        name: "FK_TaskStatuses_TaskRequests_TaskRequestID",
                        column: x => x.TaskRequestID,
                        principalTable: "TaskRequests",
                        principalColumn: "TaskRequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Childrens",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCard = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthStatues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childrens", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Childrens_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresss",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Childrens_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeceasedForms",
                columns: table => new
                {
                    WelfareFormId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [WelfareFormSequence]"),
                    EmployeeID1 = table.Column<int>(type: "int", nullable: true),
                    EmployeeID2 = table.Column<int>(type: "int", nullable: true),
                    DeceasedFormID = table.Column<int>(type: "int", nullable: false),
                    DateOfDeceased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonOfDeceased = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeceasedForms", x => x.WelfareFormId);
                    table.ForeignKey(
                        name: "FK_DeceasedForms_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeceasedForms_Employees_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_DeceasedForms_Employees_EmployeeID2",
                        column: x => x.EmployeeID2,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    TaskRequestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Documents_TaskRequests_TaskRequestID",
                        column: x => x.TaskRequestID,
                        principalTable: "TaskRequests",
                        principalColumn: "TaskRequestID");
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCard = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthStatues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Parents_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresss",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Parents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    RealEstateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealEstateTypeId = table.Column<int>(type: "int", nullable: true),
                    OwnOrRent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstateNumber = table.Column<int>(type: "int", nullable: false),
                    RealEstateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeceasedID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.RealEstateId);
                    table.ForeignKey(
                        name: "FK_RealEstates_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_RealEstates_RealEstateTypes_RealEstateTypeId",
                        column: x => x.RealEstateTypeId,
                        principalTable: "RealEstateTypes",
                        principalColumn: "RealEstateTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Siblings",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCard = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthStatues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    SiblingId = table.Column<int>(type: "int", nullable: false),
                    BrotherOrStepBrother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siblings", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Siblings_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresss",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Siblings_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spouses",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCard = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthStatues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    SpouseId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouses", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Spouses_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresss",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Spouses_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_AddressId",
                table: "Childrens",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_EmployeeID",
                table: "Childrens",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeceasedForms_EmployeeID",
                table: "DeceasedForms",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeceasedForms_EmployeeID1",
                table: "DeceasedForms",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_DeceasedForms_EmployeeID2",
                table: "DeceasedForms",
                column: "EmployeeID2");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeeID",
                table: "Documents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TaskRequestID",
                table: "Documents",
                column: "TaskRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_AddressId",
                table: "Parents",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_EmployeeID",
                table: "Parents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_EmployeeID",
                table: "RealEstates",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_RealEstateTypeId",
                table: "RealEstates",
                column: "RealEstateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_AddressId",
                table: "Siblings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Siblings_EmployeeID",
                table: "Siblings",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Spouses_AddressId",
                table: "Spouses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouses_EmployeeID",
                table: "Spouses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskRequests_WelfareFormId",
                table: "TaskRequests",
                column: "WelfareFormId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatuses_TaskRequestID",
                table: "TaskStatuses",
                column: "TaskRequestID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Childrens");

            migrationBuilder.DropTable(
                name: "DeceasedForms");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Siblings");

            migrationBuilder.DropTable(
                name: "Spouses");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "RealEstateTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TaskRequests");

            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropSequence(
                name: "PersonSequence");

            migrationBuilder.DropSequence(
                name: "WelfareFormSequence");
        }
    }
}
