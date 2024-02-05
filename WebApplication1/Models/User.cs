using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string NameUser { get; set; } = null!;

    public virtual ICollection<User_targets> User_Targets { get; set; }

    public virtual ICollection<User_contacts> User_contacts { get; set; }

    public virtual ICollection<User_tasks> User_tasks { get; set; }


}
