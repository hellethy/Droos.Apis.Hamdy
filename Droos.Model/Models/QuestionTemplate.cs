using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class QuestionTemplate
{
    public Guid QuestionTemplateId { get; set; }

    public Guid? ExamTemplateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<AnswersTemplate> AnswersTemplates { get; set; } = new List<AnswersTemplate>();

    public virtual ExamTemplate? ExamTemplate { get; set; }
}
