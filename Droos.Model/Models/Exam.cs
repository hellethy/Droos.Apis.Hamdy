using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Exam
{
    public Guid ExamId { get; set; }

    public Guid? ExamTemplateId { get; set; }

    public Guid StudentId { get; set; }

    public double? Result { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ExamTemplate? ExamTemplate { get; set; }
}
