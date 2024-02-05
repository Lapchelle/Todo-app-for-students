using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;



    public virtual ICollection<Status_targets> Status_targets { get; set; }

    public virtual ICollection<Status_Tasks> Status_Tasks { get; set; }
}
