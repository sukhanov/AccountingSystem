namespace AccountingSystem.Models
{
    public class NewTransaction
    {
        public int Type { get; set; }
        public int ClientId { get; set; }
        public int BalanceId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}