using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Repositories
{
    public interface IAccountRepository
    {
        bool AddAccount(Account account);
        Account GetAccount(string id);
        List<Account> GetAllAccounts();
        bool UpdateAccount(string id, Account cccount);
        bool DeleteAccount(string id);
    }
}
