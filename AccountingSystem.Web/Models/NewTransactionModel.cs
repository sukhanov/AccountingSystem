namespace AccountingSystem.Web.Models
{
    public class NewTransactionModel
    {
        public int Type { get; set; }
        public int Client { get; set; }
        public int Balance { get; set; }
        public int Currency { get; set; }
        public decimal Amount { get; set; }
    }
}