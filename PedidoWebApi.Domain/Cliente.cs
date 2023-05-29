namespace ProjetoWebApi.Domain;
public class Cliente
{
    public String? Senha { get; set; }
    public required String Nome { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Pedido> pedidos { get; set; } = new();
}
