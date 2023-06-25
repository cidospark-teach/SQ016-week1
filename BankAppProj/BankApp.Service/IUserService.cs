using BankApp.Models.Enums;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public interface IUserService
    {
        User AddUser(User user);
        public User GetById(string Id);
        User GetByEmail(string email);
    }
}
