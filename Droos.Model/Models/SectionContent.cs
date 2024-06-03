using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class SectionContent
{
    public Guid SectionContentId { get; set; }

    public Guid SectionId { get; set; }

    public Guid ContentId { get; set; }
}
