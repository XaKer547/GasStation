namespace GasStation.Domain.Models
{
    public class CardOwner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public ICollection<BankCard> Cards { get; set; }
    }
}
