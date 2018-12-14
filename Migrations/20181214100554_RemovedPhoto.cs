using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEF.Migrations
{
    public partial class RemovedPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Students",
                nullable: true);
        }
    }
}
