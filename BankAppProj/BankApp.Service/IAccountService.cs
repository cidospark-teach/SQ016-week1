using BankApp.Models;
using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public interface IAccountService
    {
        Account CreateAccount(Account account);
        public List<Account> GetAll();
        public List<Account> GetUserAccounts(string userId);
        public bool UpdateAccount(string id, Account account);
        public int RowCount();
        public Account GetById(string Id);
    }
}
