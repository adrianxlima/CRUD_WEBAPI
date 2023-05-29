using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoWebApi.Domain;
public class PedidoProduto
{
    [JsonIgnore]
    [ForeignKey(nameof(idProduto))]
    public Produto Produto {get; set;}
    public Guid IdPedido {get; set;}
    public Guid idProduto {get; set;}
    public int Quantidade {get; set;}
    public decimal ValorTotalLinha {get; set;}
    [JsonIgnore]
    [ForeignKey(nameof(IdPedido))]
    public Pedido Pedido { get; set; }
}
