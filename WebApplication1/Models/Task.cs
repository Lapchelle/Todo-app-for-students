using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Status_Tasks> Status_Tasks { get; set; }


    public virtual ICollection<User_tasks> User_tasks { get; set; }
}
