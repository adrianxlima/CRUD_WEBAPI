namespace ProjetoWebApi.Domain;
public class Cliente
{
    public string Senha;

    public string Nome {get; set;}
    public Guid Id {get; set;} = Guid.NewGuid();
    public List<Pedido> pedidos { get; set; } = new();
    public ICollection<Cliente> Clientes { get; set; }
    
}
