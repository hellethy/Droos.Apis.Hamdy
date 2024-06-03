using Droos.Models;

namespace Droos.Repositories.Interfaces
{
    public interface IExamTemplateRepo : IRepoBase<ExamTemplate>
    {
        Task<bool> CheckIfExist(Guid id);
    }
}
