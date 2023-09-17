// Classe Pagamento
public class Pagamento
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public TipoDePagamento Tipo { get; set; }
}
// Enum Tipo de Pagamento
public enum TipoDePagamento
{
    CartaoCredito,
    CartaoDebito,
    Boleto,
    Transferencia,
    Outro
}