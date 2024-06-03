using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Answer
{
    public Guid AnswerId { get; set; }

    public Guid QuestionTemplateId { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? AnswerTemplateId { get; set; }

    public bool? IsChecked { get; set; }

    public string? Text { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual QuestionTemplate QuestionTemplate { get; set; } = null!;
}
