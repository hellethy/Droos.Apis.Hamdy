using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Governorate
{
    public Guid GovernorateId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
