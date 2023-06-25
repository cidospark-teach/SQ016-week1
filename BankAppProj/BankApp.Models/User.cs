using System.Security.Cryptography;

namespace BankApp.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Account> Accounts { get; set; }

        public User()
        {
            Accounts= new HashSet<Account>();
        }
    }
}