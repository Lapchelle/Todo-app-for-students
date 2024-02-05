using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

   

   

    public virtual ICollection<User_contacts> User_contacts { get; set; }
}
