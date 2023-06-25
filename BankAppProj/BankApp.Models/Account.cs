using BankApp.Models.Enums;
using System.Transactions;

namespace BankApp.Models
{
    public class Account: BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }

        public decimal Balance { get; set; }

        public string UserId { get; set; }
        public User User { get; set; } // navigation property
        public ICollection<BankTransaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new HashSet<BankTransaction>();
        }
    }
}