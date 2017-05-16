using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPizza.Data.Migrations
{
    public partial class MyFirstMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Origin_Pizzas_PizzaId",
                table: "Origin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Origin",
                table: "Origin");

            migrationBuilder.RenameTable(
                name: "Origin",
                newName: "Orgins");

            migrationBuilder.RenameIndex(
                name: "IX_Origin_PizzaId",
                table: "Orgins",
                newName: "IX_Orgins_PizzaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orgins",
                table: "Orgins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orgins_Pizzas_PizzaId",
                table: "Orgins",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orgins_Pizzas_PizzaId",
                table: "Orgins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orgins",
                table: "Orgins");

            migrationBuilder.RenameTable(
                name: "Orgins",
                newName: "Origin");

            migrationBuilder.RenameIndex(
                name: "IX_Orgins_PizzaId",
                table: "Origin",
                newName: "IX_Origin_PizzaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Origin",
                table: "Origin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Origin_Pizzas_PizzaId",
                table: "Origin",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
