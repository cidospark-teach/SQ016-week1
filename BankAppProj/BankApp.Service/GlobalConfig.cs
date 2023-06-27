using BankingApp.Data;
using BankingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public static class GlobalConfig
    {
        private static IUserRepository UserRepo;
        private static IAccountRepository AccountRepo;
        private static IBankTransactionRepository TranxRepo;
        public static IAccountService AccountService;
        public static IBankTransactionService BankTranxService;
        public static IUserService UserService;
        public static void Initialize()
        {
            DataStore db = new DataStore();
            UserRepo = new UserRepository(db);
            AccountRepo = new  AccountRepository(db);
            TranxRepo = new  BankTransactionRepository(db);

            AccountService = new AccountService(AccountRepo);
            BankTranxService = new BankTransactionService(TranxRepo, AccountRepo);
            UserService = new UserService(UserRepo);
        }
    }
}
