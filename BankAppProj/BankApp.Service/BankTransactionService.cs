using BankApp.Models;
using BankingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public class BankTransactionService : IBankTransactionService
    {
        private readonly IBankTransactionRepository _trnxRepo;
        private readonly IAccountRepository _accountRepo;
        public BankTransactionService(IBankTransactionRepository trnxRepo, IAccountRepository accountRepo)
        {
            _trnxRepo = trnxRepo;
            _accountRepo = accountRepo;
        }

        public BankTransaction MakeDeposit(Account reciever, BankTransaction tranx)
        {
            if (reciever == null) throw new ArgumentNullException("Receiver's Account object is null.");
            if (tranx == null) throw new ArgumentNullException("Transaction object is null.");

            reciever.Balance += tranx.Amount;

            if(_trnxRepo.AddTransaction(tranx))
            {
                if(_accountRepo.UpdateAccount(reciever.Id, reciever))
                    return tranx;
            }

            throw new Exception("Failed to make deposit transaction");
        }

        public BankTransaction MakeWithdrawal(Account sender, BankTransaction tranx)
        {
            if (sender == null) throw new ArgumentNullException("Sender's Account object is null.");
            if (tranx == null) throw new ArgumentNullException("Transaction object is null.");

            if (sender.Balance < tranx.Amount)
            {
                throw new Exception("Insufficient fund!");
            }

            if (sender.AccountType.ToString().Equals("SAVINGS"))
            {
                if(sender.Balance <= 1000)
                {
                    throw new Exception("Transaction amount limit of 1000 reached!");
                }
            }

            sender.Balance -= tranx.Amount;

            if (_trnxRepo.AddTransaction(tranx))
            {
                if (_accountRepo.UpdateAccount(sender.Id, sender))
                    return tranx;
            }

            throw new Exception("Failed to make withdrawal transaction");
        }


        public BankTransaction MakeTransfer(Account sender, Account receiver, BankTransaction tranx)
        {
            this.MakeWithdrawal(sender, tranx);
            this.MakeDeposit(receiver, tranx);

            return tranx;
        }

        public List<BankTransaction> GetUserTransactions(string accountNum)
        {
            var trans = _trnxRepo.GetAllTransactions();
            if (trans.Count > 0) { 
                return trans.Where(x => x.SenderAccountNumber == accountNum ||
                            x.RecieverAccountNumber == accountNum).ToList();
            }

            throw new Exception("No result found for user's transactions");
        }
    }
}
