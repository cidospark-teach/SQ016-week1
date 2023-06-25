using BankApp.Models;

namespace BankingApp.Data
{
    public class DataStore
    {
        public ICollection<User> Users { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<BankTransaction> Transactions { get; set; }

        public DataStore()
        {
            Users = new HashSet<User>();
            Accounts = new HashSet<Account>();
            Transactions = new HashSet<BankTransaction>();
        }
    }
}