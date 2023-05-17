namespace GasStation.Domain.Models
{
    /// <summary>
    /// Карта лояльности 
    /// </summary>
    public class LoyaltyCard
    {
        public int Id { get; set; }
        public CardOwner Owner { get; set; }
        public double Balance { get; set; }
    }
}
