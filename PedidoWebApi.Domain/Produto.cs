using System.Collections.ObjectModel;

namespace ProjetoWebApi.Domain;
public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public ICollection<Produto> Produtos { get; set; }
    public List<PedidoProduto> PedidoProdutos {get;set;}

    public Produto()
    {
        Collection<PedidoProduto> pedidoProdutos = new Collection<PedidoProduto>();
    }
}
