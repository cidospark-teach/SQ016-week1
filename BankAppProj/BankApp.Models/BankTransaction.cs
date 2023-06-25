using BankApp.Models.Enums;

namespace BankApp.Models
{
    public class BankTransaction: BaseEntity
    {
        public TransactionType TransactionType { get; set; }
        public TransactionScope TransactionScope { get; set; }
        public string SenderAccountName { get; set; }
        public string SenderAccountNumber { get; set; }
        public string RecieverAccountName { get; set; }
        public string RecieverAccountNumber { get; set; }

        public AccountType AccountType { get; set; }

        public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.PROCESSING;

        public decimal Amount { get; set; }
         
        public string Description { get; set; }
    }
}