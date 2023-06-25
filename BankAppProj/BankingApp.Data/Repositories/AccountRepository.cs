using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataStore _db;
        public AccountRepository(DataStore db)
        {
            _db = db; 
        }

        public bool AddAccount(Account account)
        {
            var countBefore = _db.Accounts.Count;
            _db.Accounts.Add(account);
            var countAfter = _db.Accounts.Count;

            if (countAfter > countBefore)
                return true;
            return false;
        }

        public Account GetAccount(string id)
        {
            return _db.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public List<Account> GetAllAccounts()
        {
            return _db.Accounts.ToList();
        }

        public bool UpdateAccount(string id, Account account)
        {
            if (this.DeleteAccount(id))
                return this.AddAccount(account);

            return false;
        }

        public bool DeleteAccount(string id)
        {
            var countBefore = _db.Accounts.Count;
            var account = GetAccount(id);
            if (account != null)
            {
                _db.Accounts.Remove(account);
                var countAfter = _db.Accounts.Count;

                if (countAfter < countBefore)
                    return true;
            }

            return false;
        }
    }
}
