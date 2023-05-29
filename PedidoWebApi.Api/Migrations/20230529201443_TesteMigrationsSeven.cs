using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoWebApi.Api.Migrations
{
    /// <inheritdoc />
    public partial class TesteMigrationsSeven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Pedidos_idProduto",
                table: "PedidoProdutos");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Pedidos_IdPedido",
                table: "PedidoProdutos",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Pedidos_IdPedido",
                table: "PedidoProdutos");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Pedidos_idProduto",
                table: "PedidoProdutos",
                column: "idProduto",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
