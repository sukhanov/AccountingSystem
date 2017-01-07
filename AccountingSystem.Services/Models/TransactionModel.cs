namespace AccountingSystem.Services.Models
{
    public class TransactionModel
    {
        public int Type { get; set; }
        public int ClientId { get; set; }
        public int? ClientToId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
    }
}
