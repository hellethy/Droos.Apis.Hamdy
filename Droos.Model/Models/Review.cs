using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Review
{
    public Guid ReviewId { get; set; }

    public int? Rate { get; set; }

    public string? ItemType { get; set; }

    public Guid? ItemId { get; set; }

    public string? Comment { get; set; }

    public Guid StudentId { get; set; }

    public virtual Content? Item { get; set; }
}
