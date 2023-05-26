using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ProjetoWebApi.Domain;
public class Pedido
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    
    public ICollection<Pedido> Pedidos { get; set; }

    public List<PedidoProduto> PedidoProdutos {get;set;}
    [JsonIgnore]
    public Cliente cliente { get; set; }
    public Guid idCliente { get; set; }
    public object ValorTotal { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }

    Collection<PedidoProduto> pedidoProdutos = new Collection<PedidoProduto>();
    
}
