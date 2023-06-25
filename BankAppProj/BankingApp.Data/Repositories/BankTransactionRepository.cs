using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Repositories
{
    public class BankTransactionRepository : IBankTransactionRepository
    {
        private readonly DataStore _db;
        public BankTransactionRepository(DataStore db)
        {
            _db = db;
        }

        public bool AddTransaction(BankTransaction bankTransaction)
        {
            var countBefore = _db.Transactions.Count;
            _db.Transactions.Add(bankTransaction);
            var countAfter = _db.Transactions.Count;

            if (countAfter > countBefore)
                return true;
            return false;
        }

        public List<BankTransaction> GetAllTransactions()
        {
            return _db.Transactions.ToList();
        }

        public BankTransaction GetTransaction(string id)
        {
            return _db.Transactions.FirstOrDefault(x => x.Id == id); 
        }

    }
}
