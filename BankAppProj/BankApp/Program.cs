// See https://aka.ms/new-console-template for more information
using BankApp;
using BankApp.Models;
using BankApp.Models.Enums;
using BankApp.Service;

GlobalConfig.Initialize();

#region global state
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

AppHelper.DisplayOperations(windowWidth, user);


//int tranx = 0;
//int counter2 = 0;


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


AppHelper.DisplayOperations(windowWidth, user);

