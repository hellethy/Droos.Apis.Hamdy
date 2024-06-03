using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class AnswersTemplate
{
    public Guid AnswerTemplateId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsCorrect { get; set; }

    public Guid? QuestionTemplateId { get; set; }

    public virtual QuestionTemplate? QuestionTemplate { get; set; }
}
