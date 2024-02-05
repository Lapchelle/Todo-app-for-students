namespace WebApplication1.Models
{
    public class User_contacts
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public User User { get; set; }
        public Contact Contact { get; set; }
    }
}
