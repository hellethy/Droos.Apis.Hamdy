using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class PayableItem
{
    public Guid PayableItemId { get; set; }

    public int? PayableItemType { get; set; }

    public Guid? SectionId { get; set; }

    public Guid? SubjectId { get; set; }

    public Guid? ChapterId { get; set; }

    public int? ValidFor { get; set; }

    public Guid? ContentId { get; set; }

    public decimal? Price { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual Content? Content { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
