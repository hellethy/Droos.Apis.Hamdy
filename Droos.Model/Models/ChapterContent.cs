using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class ChapterContent
{
    public Guid ChapterContentId { get; set; }

    public Guid ChapterId { get; set; }

    public Guid ContentId { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Content Content { get; set; } = null!;
}
