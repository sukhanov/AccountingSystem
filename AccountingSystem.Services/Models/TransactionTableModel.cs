using System;
using AccountingSystem.Shared.Infra;

namespace AccountingSystem.Services.Models
{
    public class TransactionTableModel:TransactionModel
    {
        public DateTime DateTime { get; set; } 
        public string Client { get; set; }
        public string ClientTo { get; set; }
        public string Currency { get; set; }
        public DateTime? ArchiveDatetime { get; set; }
        public TransactionType TypeDisplay => (TransactionType) Type;
        public bool Archive => ArchiveDatetime.HasValue;
    }
}