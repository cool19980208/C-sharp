﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core1.Migrations
{
    public partial class AddAuthorName_ModifyTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "T_Persons",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "T_Persons",
                type: "float",
                nullable: true
            );

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "T_Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "T_Books",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    Id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Dog");

            migrationBuilder.DropColumn(name: "BirthPlace", table: "T_Persons");

            migrationBuilder.DropColumn(name: "Salary", table: "T_Persons");

            migrationBuilder.DropColumn(name: "AuthorName", table: "T_Books");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "T_Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50
            );
        }
    }
}
