using System;
using System.Collections.Generic;

namespace Entity;

public partial class ViewLog
{
    public int Id { get; set; }

    public string? Ip { get; set; }

    public string? FullName { get; set; }

    public DateTime? ViewDate { get; set; }

    public string? DocumentName { get; set; }
}
