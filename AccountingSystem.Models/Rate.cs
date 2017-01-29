namespace AccountingSystem.Models
{
    public class Rate
    {
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public double Val { get; set; }
    }
}