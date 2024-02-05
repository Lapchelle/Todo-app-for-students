namespace WebApplication1.Models
{
    public class Status_Tasks
    {
        public int StatusId { get; set; }
        public int TaskId { get; set; }
        public Status Status { get; set; }
        public Task Task { get; set; }
    }
}
