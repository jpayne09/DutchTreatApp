using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dutchtreat.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 3, 24, 13, 23, 47, 51, DateTimeKind.Utc).AddTicks(8393));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 3, 24, 13, 0, 19, 857, DateTimeKind.Utc).AddTicks(4180));
        }
    }
}
