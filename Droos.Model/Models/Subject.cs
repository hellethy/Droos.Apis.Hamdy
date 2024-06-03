using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Subject
{
    public Guid SubjectId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? GradeId { get; set; }

    public virtual Grade? Grade { get; set; }

    public virtual ICollection<PayableItem> PayableItems { get; set; } = new List<PayableItem>();

    public virtual ICollection<SubjectSection> SubjectSections { get; set; } = new List<SubjectSection>();
}
