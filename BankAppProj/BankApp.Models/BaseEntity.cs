namespace BankApp.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CreatedOn { get; set; } = DateTime.Now.ToString();
        public string UpatedOn { get; set; } = DateTime.Now.ToString();
    }
}