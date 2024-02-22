using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class Table2
{
    public int? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public long? PhoneNumber { get; set; }

    public virtual Table1? User { get; set; }
}
