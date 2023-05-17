namespace GasStation.Domain.Models
{
    /// <summary>
    /// Карта, выданная банком
    /// </summary>
    public class BankCard
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpressionDate { get; set; }

        public CardType Type { get; set; }

        public Issuer Issuer { get; set; }

        public CardOwner Owner { get; set; }

        public double Balance { get; set; }
    }
}