using System.Collections.ObjectModel;

namespace ProjetoWebApi.Domain;
public class Produto
{
    public Guid Id { get; set; }
    public required String Nome { get; set; }
    public decimal Valor { get; set; }
    public List<PedidoProduto> PedidoProdutos {get;set;}
    public int Quantidade { get; set; }
}
