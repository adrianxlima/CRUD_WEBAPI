using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoWebApi.Api.Migrations
{
    /// <inheritdoc />
    public partial class TesteMigrationsSix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProduto_Pedidos_idProduto",
                table: "PedidoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProduto_Produtos_idProduto",
                table: "PedidoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProduto",
                table: "PedidoProduto");

            migrationBuilder.RenameTable(
                name: "PedidoProduto",
                newName: "PedidoProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProduto_idProduto",
                table: "PedidoProdutos",
                newName: "IX_PedidoProdutos_idProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos",
                columns: new[] { "IdPedido", "idProduto" });

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Pedidos_idProduto",
                table: "PedidoProdutos",
                column: "idProduto",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Produtos_idProduto",
                table: "PedidoProdutos",
                column: "idProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Pedidos_idProduto",
                table: "PedidoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Produtos_idProduto",
                table: "PedidoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos");

            migrationBuilder.RenameTable(
                name: "PedidoProdutos",
                newName: "PedidoProduto");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProdutos_idProduto",
                table: "PedidoProduto",
                newName: "IX_PedidoProduto_idProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProduto",
                table: "PedidoProduto",
                columns: new[] { "IdPedido", "idProduto" });

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProduto_Pedidos_idProduto",
                table: "PedidoProduto",
                column: "idProduto",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProduto_Produtos_idProduto",
                table: "PedidoProduto",
                column: "idProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
