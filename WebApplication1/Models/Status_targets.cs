namespace WebApplication1.Models
{
    public class Status_targets
    {
        public int StatusId { get; set; }
        public int TargetId { get; set; }
        public Status Status { get; set; }
        public Target Target { get; set; }
    }
}
