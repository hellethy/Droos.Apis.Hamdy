using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class ExamTemplate
{
    public Guid ExamTemplateId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<QuestionTemplate> QuestionTemplates { get; set; } = new List<QuestionTemplate>();
}
