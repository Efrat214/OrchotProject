using System;
using System.Collections.Generic;

namespace Entity;

public partial class TblAssistValue
{
    public int TableCode { get; set; }

    public string Code { get; set; } = null!;

    public string? Value1 { get; set; }

    public bool? Active { get; set; }

    public virtual TblAssist TableCodeNavigation { get; set; } = null!;
}
