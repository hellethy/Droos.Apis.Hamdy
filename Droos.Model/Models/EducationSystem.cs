using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class EducationSystem
{
    public Guid EducationSystemId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
