using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ProjetoWebApi.Domain;
public class Pedido
{
    public Guid Id { get; set; }
    public Boolean pagamento {get; set;} = false;
    public List<PedidoProduto> PedidoProdutos {get;set;} = new();
    [JsonIgnore]
    public Cliente cliente { get; set; }
    public Guid idCliente { get; set; }
    public decimal ValorTotal { get; set; }    
}
