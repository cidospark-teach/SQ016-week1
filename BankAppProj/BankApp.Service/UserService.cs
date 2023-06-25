using BankApp.Models;
using BankingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException("User object is null.");

            if(_userRepo.AddUser(user)) return user;

            throw new Exception("Failed to add new User");

        }

        public User GetById(string Id)
        {
            var user = _userRepo.GetUserById(Id);
            if(user != null) return user;

            throw new Exception($"Could not find user with id: {Id}");
        }

        public User GetByEmail(string email)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user != null) return user;

            throw new Exception($"Could not find user with email: {email}");
        }
    }
}
