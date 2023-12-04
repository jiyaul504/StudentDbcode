using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDbcode.Migrations
{
    /// <inheritdoc />
    public partial class fROGEIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_IDType",
                columns: table => new
                {
                    IDTypeID = table.Column<int>(type: "int", nullable: false),
                    IDType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_IDTy__3B6BCFA7F7E959E4", x => x.IDTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCount__10D160BF57F2DAED", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "tblGender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblGende__4E24E817571E227A", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "tblStudent",
                columns: table => new
                {
                    StudentGID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlaceofBirth = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    IDType = table.Column<int>(type: "int", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    mDate = table.Column<DateOnly>(type: "date", nullable: false),
                    mDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TblCountryCountryId = table.Column<int>(type: "int", nullable: false),
                    TblGenderGenderId = table.Column<int>(type: "int", nullable: false),
                    TblIdtypeIdtypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblStude__BCF7ACADF87B2EA3", x => x.StudentGID);
                    table.ForeignKey(
                        name: "FK_tblStudent_tblCountry_TblCountryCountryId",
                        column: x => x.TblCountryCountryId,
                        principalTable: "tblCountry",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblStudent_tblGender_TblGenderGenderId",
                        column: x => x.TblGenderGenderId,
                        principalTable: "tblGender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblStudent_tbl_IDType_TblIdtypeIdtypeId",
                        column: x => x.TblIdtypeIdtypeId,
                        principalTable: "tbl_IDType",
                        principalColumn: "IDTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblStudent_TblCountryCountryId",
                table: "tblStudent",
                column: "TblCountryCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblStudent_TblGenderGenderId",
                table: "tblStudent",
                column: "TblGenderGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblStudent_TblIdtypeIdtypeId",
                table: "tblStudent",
                column: "TblIdtypeIdtypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblStudent");

            migrationBuilder.DropTable(
                name: "tblCountry");

            migrationBuilder.DropTable(
                name: "tblGender");

            migrationBuilder.DropTable(
                name: "tbl_IDType");
        }
    }
}
