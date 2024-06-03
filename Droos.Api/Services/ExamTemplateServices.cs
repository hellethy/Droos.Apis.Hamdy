using AutoMapper;
using Droos.Api.Dtos;
using Droos.Api.Services.Interfaces;
using Droos.Repositories.Interfaces;

namespace Droos.Api.Services
{
//    public class ChapterServices : IExamTemplateServices
//    {
//        private readonly IExamTemplateRepo _examTemplateRepo;
//        private readonly IMapper _mapper;
//        public ChapterServices(IExamTemplateRepo examTemplateRepo)
//        {
//            _examTemplateRepo = examTemplateRepo;
//        }
//        public Task<ChapterServices> Create(CreateChapterTeDto examTemplate)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<bool> Delete(Guid id)
//        {
//            bool IsExist = await _examTemplateRepo.CheckIfExist(id);
//            if (IsExist)
//            {
//                await _examTemplateRepo.Delete(id);
//                return true;
//            }
//            return false;

//        }

//        public async Task<IEnumerable<CreateChapterTeDto>> GetAll()
//        {
//            var result = await _examTemplateRepo.GetAll();
//            var ExamTemplates = _mapper.Map<IEnumerable<CreateChapterTeDto>>(result);
//            return ExamTemplates;
//        }

//        public Task<ChapterServices> GetById(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ChapterServices> Update(CreateChapterTeDto examTemplate)
//        {
//            throw new NotImplementedException();
//        }


    

//    }
}
