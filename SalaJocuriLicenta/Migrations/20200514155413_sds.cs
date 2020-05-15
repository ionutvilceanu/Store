using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaJocuriLicenta.Migrations
{
    public partial class sds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Favorits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Favorits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorits_ApplicationUserId1",
                table: "Favorits",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorits_AspNetUsers_ApplicationUserId1",
                table: "Favorits",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorits_AspNetUsers_ApplicationUserId1",
                table: "Favorits");

            migrationBuilder.DropIndex(
                name: "IX_Favorits_ApplicationUserId1",
                table: "Favorits");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Favorits");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Favorits");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
