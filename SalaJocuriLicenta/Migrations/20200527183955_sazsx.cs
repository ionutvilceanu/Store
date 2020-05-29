using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaJocuriLicenta.Migrations
{
    public partial class sazsx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCartItems_SCart_SCartId",
                table: "SCartItems");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCart",
                table: "SCart");

            migrationBuilder.RenameTable(
                name: "SCart",
                newName: "SCarts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCarts",
                table: "SCarts",
                column: "SCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_SCartItems_SCarts_SCartId",
                table: "SCartItems",
                column: "SCartId",
                principalTable: "SCarts",
                principalColumn: "SCartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCartItems_SCarts_SCartId",
                table: "SCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCarts",
                table: "SCarts");

            migrationBuilder.RenameTable(
                name: "SCarts",
                newName: "SCart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCart",
                table: "SCart",
                column: "SCartId");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookDate = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<int>(nullable: false),
                    YourName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_ShoppingCartId",
                table: "Book",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_SCartItems_SCart_SCartId",
                table: "SCartItems",
                column: "SCartId",
                principalTable: "SCart",
                principalColumn: "SCartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
