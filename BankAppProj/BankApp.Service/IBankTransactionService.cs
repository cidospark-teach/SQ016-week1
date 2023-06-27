using BankApp.Models.Enums;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public interface IBankTransactionService
    {
        BankTransaction MakeDeposit(Account reciever, BankTransaction tranx);
        BankTransaction MakeWithdrawal(Account sender, BankTransaction tranx);
        BankTransaction MakeTransfer(Account sender, Account receiver, BankTransaction tranx);

        List<BankTransaction> GetUserTransactions(string accountNum);

    }
}
