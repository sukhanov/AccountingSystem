namespace AccountingSystem.Web.Models
{
    public class NewTransaction
    {
        public int Type { get; set; }
        public int Client { get; set; }
        public int Currency { get; set; }
        public decimal Amount { get; set; }
    }
}