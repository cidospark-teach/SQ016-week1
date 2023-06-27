using BankApp.Models.Enums;
using BankApp.Models;
using BankingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Data.Repositories;

namespace BankApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;

        public AccountService(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Account CreateAccount(Account account)
        {
            if (account.AccountName.Length < 3)
                throw new Exception("Account name should be more than 3 characters");

            var rand = new Random();
            account.AccountNumber = rand.Next(0, 1000000000).ToString("D10");
            
            if(_accountRepo.AddAccount(account))
                return account;

            throw new Exception("Failed to create account.");
        }

        public List<Account> GetAll()
        {
            var users = _accountRepo.GetAllAccounts();
            if(users.Count > 0) return users;

            throw new Exception($"No results found for users");
        }

        public Account GetById(string Id)
        {
            var account =  _accountRepo.GetAccount(Id); 
            if (account != null) return account;

            throw new Exception($"Could not find account with id: {Id}");
        }

        public List<Account> GetUserAccounts(string userId)
        {
            var accounts = GetAll().Where(x => x.UserId == userId);
            if (accounts.Count() > 0) return accounts.ToList();

            throw new Exception($"Could not find account for user with id: {userId}");
        }

        public int RowCount()
        {
            return _accountRepo.GetAllAccounts().Count;
        }

        public bool UpdateAccount(string id, Account account)
        {
            return _accountRepo.UpdateAccount(id, account);
        }



        // Todo: Update Method

        // Todo: Delete Method
    }
}
