using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jonny.AllDemo.EntityFrameworkCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 12, nullable: true),
                    Like = table.Column<string>(maxLength: 200, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Udouble = table.Column<double>(nullable: false),
                    Ufloat = table.Column<float>(nullable: false),
                    Udecimal = table.Column<decimal>(nullable: false),
                    Uuint = table.Column<long>(nullable: false),
                    Ulong = table.Column<long>(nullable: false),
                    Uulong = table.Column<decimal>(nullable: false),
                    UInt16 = table.Column<short>(nullable: false),
                    UInt32 = table.Column<int>(nullable: false),
                    UInt64 = table.Column<long>(nullable: false),
                    UuInt16 = table.Column<int>(nullable: false),
                    UuInt32 = table.Column<long>(nullable: false),
                    UuInt64 = table.Column<decimal>(nullable: false),
                    Ubyte = table.Column<byte>(nullable: false),
                    Uchar = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
