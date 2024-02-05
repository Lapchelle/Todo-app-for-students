namespace WebApplication1.Models
{
    public class User_tasks
    {    
    
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public User User { get; set; }
        public Task Task { get; set; }
    
    }
}
