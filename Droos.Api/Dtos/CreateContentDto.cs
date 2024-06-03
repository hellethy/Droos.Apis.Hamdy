namespace Droos.Api.Dtos
{
    public class CreateContentDto
    {
        public Guid ContentId { get; set; }

        public string Name { get; set; } = null!;

        public int Type { get; set; }

        public Guid? ExamId { get; set; }

        public Guid? McqId { get; set; }

        public int? DurationInSeconds { get; set; }

        public bool? IsFree { get; set; }

        public string? Url { get; set; }

        public string? HtmlText { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}
