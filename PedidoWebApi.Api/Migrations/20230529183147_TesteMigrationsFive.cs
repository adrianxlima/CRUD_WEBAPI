using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoWebApi.Api.Migrations
{
    /// <inheritdoc />
    public partial class TesteMigrationsFive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_ClienteId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ClienteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Clientes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Clientes");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Clientes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClienteId",
                table: "Clientes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_ClienteId",
                table: "Clientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
