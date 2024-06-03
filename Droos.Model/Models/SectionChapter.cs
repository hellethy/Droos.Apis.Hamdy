using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class SectionChapter
{
    public Guid SectionChapterId { get; set; }

    public Guid SectionId { get; set; }

    public Guid ChapterId { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;
}
