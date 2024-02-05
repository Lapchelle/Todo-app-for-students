namespace WebApplication1.Models
{
    public class User_targets
    {
        public int UserId { get; set; }
        public int TargetId { get; set; }
        public User User { get; set; }
        public Target Target { get; set; }
    }
}
