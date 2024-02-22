using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class TableData
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
