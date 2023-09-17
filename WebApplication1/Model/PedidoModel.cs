

// Classe Pedido
public class Pedido
{
    public int Id { get; set; }
    public List<ItemNoCarrinho> Itens { get; set; }
    public Cliente Cliente { get; set; }
    public Transportadora Transportadora { get; set; }
    public Pagamento Pagamento { get; set; }
}
