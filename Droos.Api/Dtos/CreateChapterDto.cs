namespace Droos.Api.Dtos
{
    public class CreateChapterDto
    {
        public Guid ChapterId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}
