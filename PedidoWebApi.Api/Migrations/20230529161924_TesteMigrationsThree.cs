using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoWebApi.Api.Migrations
{
    /// <inheritdoc />
    public partial class TesteMigrationsThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pedidos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Pedidos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
