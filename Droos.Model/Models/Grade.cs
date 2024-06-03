using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Grade
{
    public Guid GradeId { get; set; }

    public string Name { get; set; } = null!;

    public Guid GovernorateId { get; set; }

    public Guid EducationSystemId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual EducationSystem EducationSystem { get; set; } = null!;

    public virtual Governorate Governorate { get; set; } = null!;

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
