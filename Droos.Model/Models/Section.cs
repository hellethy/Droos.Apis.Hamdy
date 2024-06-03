using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Section
{
    public Guid SectionId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<PayableItem> PayableItems { get; set; } = new List<PayableItem>();

    public virtual ICollection<SectionChapter> SectionChapters { get; set; } = new List<SectionChapter>();

    public virtual ICollection<SubjectSection> SubjectSections { get; set; } = new List<SubjectSection>();
}
