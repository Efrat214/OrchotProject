using System;
using System.Collections.Generic;

namespace Entity;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? MailAddress { get; set; }

    public string? Department { get; set; }

    public string? Mobile { get; set; }

    public bool? Admin { get; set; }

    public bool? Active { get; set; }
}
