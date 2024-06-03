using Droos.Model.Context;
using Droos.Models;
using Droos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Droos.Repositories
{
    public class ExamTemplateRepo : RepoBase<ExamTemplate>, IExamTemplateRepo
    {

        public ExamTemplateRepo(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckIfExist(Guid id)
        {
            return await DbContext.ExamTemplates.AnyAsync(e => e.ExamTemplateId == id);
        }
    }
}
