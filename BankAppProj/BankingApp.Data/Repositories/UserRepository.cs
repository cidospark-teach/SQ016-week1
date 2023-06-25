using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataStore _db;
        public UserRepository(DataStore db)
        {
            _db = db;
        }
        public bool AddUser(User user)
        {
            var countBefore = _db.Users.Count;
            _db.Users.Add(user);
            var countAfter = _db.Users.Count;

            if (countAfter > countBefore)
                return true;
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(string id)
        {
            return _db.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
