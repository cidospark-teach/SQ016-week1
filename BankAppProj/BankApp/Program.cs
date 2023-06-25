// See https://aka.ms/new-console-template for more information
using BankApp;
using BankApp.Models;
using BankApp.Models.Enums;
using BankApp.Service;

GlobalConfig.Initialize();

#region global state
User user = new User();
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

Thread.Sleep(5000);
Console.Clear();

AppHelper.DisplayTitle(windowWidth);

Console.WriteLine();
Console.WriteLine($"Welcome! {user.FirstName} - you are logged-In");

Console.WriteLine();
Console.WriteLine("[1] Deposit \t | \t[2] Widthdrawal");
Console.WriteLine();
Console.WriteLine("[3] Transfer \t | \t[4] Logout ");
Console.WriteLine();


int tranx = 0;
int counter2 = 0;
while (tranx < 1 || tranx > 4)
{
    if (counter2 > 0)
    {
        Console.WriteLine("Invalid entry!");
    }
    Console.Write("\nChoose a transaction you wish to carryout\t");
    counter2++;

    tranx = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine();



