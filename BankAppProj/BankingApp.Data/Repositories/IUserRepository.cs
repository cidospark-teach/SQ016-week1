using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Repositories
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        User GetUserById(string id);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
    }
}
