using System;
using AccountingSystem.Shared.Infra;

namespace AccountingSystem.Models
{
    public class Transaction
    {
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string ClientName { get; set; }
        public string Currency { get; set; }
        public DateTime? ArchiveDatetime { get; set; }

        public TransactionType TypeDisplay => (TransactionType)Type;
    }
}