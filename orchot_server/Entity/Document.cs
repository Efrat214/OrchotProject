using System;
using System.Collections.Generic;

namespace Entity;

public partial class Document
{
    public int Id { get; set; }

    public string? DocumentName { get; set; }

    public string? Organization { get; set; }

    public string? BusinessUnit { get; set; }

    public string? Department { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public bool? AlertActive { get; set; }

    public DateTime? LastAlert { get; set; }

    public string? MailAddress { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? NumDaysExp { get; set; }

    public string? DocType { get; set; }

    public bool? Deleted { get; set; }

    public string? DocLink { get; set; }


    public virtual ICollection<DocReferance> DocReferances { get; } = new List<DocReferance>();
}
