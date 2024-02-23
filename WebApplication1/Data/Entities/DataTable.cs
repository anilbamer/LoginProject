using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class DataTable
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public long? Phonenumber { get; set; }
}
