﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace 一对一.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Deliveries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Deliveries_T_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "T_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Deliveries_OrderId",
                table: "T_Deliveries",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Deliveries");

            migrationBuilder.DropTable(
                name: "T_Orders");
        }
    }
}
