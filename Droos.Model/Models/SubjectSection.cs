using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class SubjectSection
{
    public Guid SubjectSectionId { get; set; }

    public Guid SubjectId { get; set; }

    public Guid SectionId { get; set; }

    public virtual Section Section { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
