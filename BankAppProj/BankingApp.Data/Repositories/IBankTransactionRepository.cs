using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Repositories
{
    public interface IBankTransactionRepository
    {
        bool AddTransaction(BankTransaction bankTransaction);
        BankTransaction GetTransaction(string id);
        List<BankTransaction> GetAllTransactions();
    }
}
