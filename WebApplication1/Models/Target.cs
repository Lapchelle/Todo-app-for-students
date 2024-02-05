using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Target
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Status_targets> Status_targets { get; set; }

    public virtual ICollection<User_targets> User_Targets { get; set; }
}
