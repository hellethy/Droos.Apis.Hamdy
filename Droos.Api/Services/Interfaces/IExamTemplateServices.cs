using Droos.Api.Dtos;

namespace Droos.Api.Services.Interfaces
{
    public interface IExamTemplateServices
    {
        Task<IEnumerable<CreateExamTemplateDto>> GetAll();
        Task<CreateExamTemplateDto> GetById(Guid id);
        Task<CreateExamTemplateDto> Create(CreateExamTemplateDto examTemplate);
        Task<CreateExamTemplateDto> Update(CreateExamTemplateDto examTemplate);
        Task<bool> Delete(Guid id);
    }
}
