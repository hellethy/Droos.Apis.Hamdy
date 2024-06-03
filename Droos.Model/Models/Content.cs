using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Content
{
    public Guid ContentId { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? McqId { get; set; }

    public int? DurationInSeconds { get; set; }

    public bool? IsFree { get; set; }

    public string? Url { get; set; }

    public string? HtmlText { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<ChapterContent> ChapterContents { get; set; } = new List<ChapterContent>();

    public virtual ICollection<PayableItem> PayableItems { get; set; } = new List<PayableItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
