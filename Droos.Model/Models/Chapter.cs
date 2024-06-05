using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Chapter
{
    public Guid ChapterId { get; set; } = Guid.NewGuid();

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<ChapterContent> ChapterContents { get; set; } = new List<ChapterContent>();

    public virtual ICollection<PayableItem> PayableItems { get; set; } = new List<PayableItem>();

    public virtual ICollection<SectionChapter> SectionChapters { get; set; } = new List<SectionChapter>();
}
