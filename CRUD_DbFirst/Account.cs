using System;
using System.Collections.Generic;

namespace CRUD_DbFirst;

public partial class Account
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string Money { get; set; } = null!;

    public string? Role { get; set; }
}
