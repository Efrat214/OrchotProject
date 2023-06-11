using System;
using System.Collections.Generic;

namespace Entity;

public partial class DocReferance
{
    public int Id { get; set; }

    public int? DocId { get; set; }

    public string? RefType { get; set; }

    public string? Ref { get; set; }

    public virtual Document? Doc { get; set; }
}
