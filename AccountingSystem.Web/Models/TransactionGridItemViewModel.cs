namespace AccountingSystem.Web.Models
{
    public class TransactionGridItemViewModel
    {
        public string Type { get; set; }
        public string Amount { get; set; }
        public string DateTime { get; set; }
        public string Client { get; set; }
        public string ClientTo { get; set; }
        public string Currency { get; set; }
        public bool Archive { get; set; }
        public string ArchiveDatetime { get; set; }
    }
}