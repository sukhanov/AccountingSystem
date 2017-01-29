namespace AccountingSystem.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int ClientId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}