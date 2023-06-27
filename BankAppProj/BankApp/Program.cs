// See https://aka.ms/new-console-template for more information
using BankApp;
using BankApp.Models;
using BankApp.Models.Enums;
using BankApp.Service;
using System.Net.Mail;

GlobalConfig.Initialize();

#region file global state
User user = new User();
Account account = new Account();
#endregion

Console.WriteLine();

int windowWidth = Console.WindowWidth - 2;

AppHelper.DisplayTitle(windowWidth);

Console.WriteLine();
Console.WriteLine("[1] Login \t OR \t[2] Register");
Console.WriteLine();

int action = 0;
int counter = 0;
while(action < 1 || action > 2)
{
    if(counter > 0)
    {
        Console.WriteLine("Invalid entry!");
    }
    Console.Write("\nEnter 1 OR 2\t");
    counter++;

    action = Convert.ToInt32(Console.ReadLine());
}

if(action == 1)
{
    Console.Write("Enter your email\t");
    string email = Console.ReadLine();
    Console.Write("Enter your password\t");
    string pass = Console.ReadLine();
    try
    {
        var dbUser = GlobalConfig.UserService.GetByEmail(email);
        if (dbUser.Password == pass)
        { 
            user = dbUser;
            Console.WriteLine("User logged-in!");
        }
        else
            throw new Exception("Invalid password");
    }catch(Exception)
    {
        Console.WriteLine("Invalid email");
    }
}


if (action == 2)
{
    Console.Write("Enter your first name\t");
    string fname = Console.ReadLine();
    Console.Write("Enter your last name\t");
    string lname = Console.ReadLine();
    Console.Write("Enter your email\t");
    string email = Console.ReadLine();
    Console.Write("Enter your password\t");
    string password = Console.ReadLine();
    try
    {
        var newUser = new User
        {
            FirstName = fname,
            LastName = lname,
            Email = email,
            Password = password
        };

        var dbUser = GlobalConfig.UserService.AddUser(newUser);
        user = dbUser;
        Console.WriteLine("User added!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

AppHelper.DisplayOperations(windowWidth, user, account); 

if(GlobalState.tranxChoice == 1)
{
    Console.Write("Enter an account name\t");
    string accName = Console.ReadLine();
    Console.Write("Select account type: [1] Saving \t [2] Current");
    int accType = int.Parse(Console.ReadLine());

    var defaultAccType = AccountType.SAVINGS;
    try
    {
        var newAcc = new Account
        {
            AccountName = accName,
            AccountType = defaultAccType,
            UserId = user.Id,
            User = user
        };

        if(accType == 1) { defaultAccType = AccountType.SAVINGS; }
        else { defaultAccType = AccountType.CURRENT; }

        account = GlobalConfig.AccountService.CreateAccount(newAcc);
        Console.WriteLine($"{newAcc.AccountType} account created!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


AppHelper.DisplayOperations(windowWidth, user, account);

if (GlobalState.tranxChoice == 2 || GlobalState.tranxChoice == 3)
{
    decimal amt = 0;
    if(GlobalState.tranxChoice == 2)
    {
        Console.Write("How much do you intend to withdraw?\t");
        amt = decimal.Parse(Console.ReadLine());
    }

    if(GlobalState.tranxChoice == 3)
    {
        Console.Write("How much do you intend to tranfer?\t");
        amt = decimal.Parse(Console.ReadLine());
    }

    Console.Write("Receipient name");
    string receipientName = Console.ReadLine();
    Console.Write("Receipient number");
    string receipientNumber = Console.ReadLine();
    Console.Write("Note");
    string note = Console.ReadLine();
    Console.Write("From which account?: [1] Saving \t [2] Current");
    int accType = int.Parse(Console.ReadLine());

    var defaultAccType = AccountType.SAVINGS;
    try
    {
        if (accType == 1) { defaultAccType = AccountType.SAVINGS; }
        else { defaultAccType = AccountType.CURRENT; }

        account = (GlobalConfig.AccountService.GetUserAccounts(user.Id))
            .FirstOrDefault(x => x.AccountType == defaultAccType);

        var tranx = new BankTransaction
        {
            TransactionType = TransactionType.WITHDRAWAL,
            TransactionScope = TransactionScope.EXTERNAL,
            TransactionStatus = TransactionStatus.COMPLETED,
            SenderAccountName = account.AccountName,
            SenderAccountNumber = account.AccountNumber,
            RecieverAccountName = receipientName,
            RecieverAccountNumber = receipientNumber,
            Description = note,
            AccountType = account.AccountType,
            Amount = amt,
        };

        if (GlobalState.tranxChoice == 2)
        {
            tranx.TransactionType= TransactionType.WITHDRAWAL;
            tranx.TransactionScope= TransactionScope.EXTERNAL;
        }

        if (GlobalState.tranxChoice == 3)
        {
            tranx.TransactionType = TransactionType.TRANSFER;
            tranx.TransactionScope = TransactionScope.INTERNAL;
        }

        account.Balance -= amt;
        GlobalConfig.AccountService.UpdateAccount(account.Id, account);
        GlobalConfig.BankTranxService.MakeWithdrawal(account, tranx);
        Console.WriteLine($"Transaction added!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

AppHelper.DisplayOperations(windowWidth, user, account);

if (GlobalState.tranxChoice == 4)
{
    Console.Write("How much do you intend to deposit?\t");
    decimal amt = decimal.Parse(Console.ReadLine());
    Console.Write("Depositor name");
    string receipientName = Console.ReadLine();
    Console.Write("Depositor number");
    string receipientNumber = Console.ReadLine();
    Console.Write("Note");
    string note = Console.ReadLine();
    Console.Write("From which account?: [1] Saving \t [2] Current");
    int accType = int.Parse(Console.ReadLine());

    var defaultAccType = AccountType.SAVINGS;
    try
    {
        if (accType == 1) { defaultAccType = AccountType.SAVINGS; }
        else { defaultAccType = AccountType.CURRENT; }

        account = (GlobalConfig.AccountService.GetUserAccounts(user.Id))
            .FirstOrDefault(x => x.AccountType == defaultAccType);

        var tranx = new BankTransaction
        {
            TransactionType = TransactionType.TRANSFER,
            TransactionScope = TransactionScope.INTERNAL,
            TransactionStatus = TransactionStatus.COMPLETED,
            SenderAccountName = account.AccountName,
            SenderAccountNumber = account.AccountNumber,
            RecieverAccountName = receipientName,
            RecieverAccountNumber = receipientNumber,
            Description = note,
            AccountType = account.AccountType,
            Amount = amt,
        };

        account.Balance += amt;
        GlobalConfig.AccountService.UpdateAccount(account.Id, account);
        GlobalConfig.BankTranxService.MakeWithdrawal(account, tranx);
        Console.WriteLine($"Transaction added!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


AppHelper.DisplayOperations(windowWidth, user, account);

if(GlobalState.tranxChoice == 5)
{
    Console.WriteLine("Coming soon...");
}