using System.Text.Json.Serialization;

namespace ProjetoWebApi.Domain;
public class PedidoProduto
{
    private int v;
    private Produto produto;

    public PedidoProduto(int v, Produto produto)
    {
        this.v = v;
        this.produto = produto;
    }

    public Guid IdPedido {get; set;}
    public Guid idProduto {get; set;}
    public int Quantidade {get; set;}
    public decimal ValorTotalLinha {get; set;}
    [JsonIgnore]
    public Pedido Pedido { get; set; }
    [JsonIgnore]
    public Produto Produto { get; set; }
}
