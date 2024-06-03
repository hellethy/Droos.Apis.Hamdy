using AutoMapper;
using Droos.Api.Dtos;
using Droos.Models;

namespace Droos.Api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateExamTemplateDto, ExamTemplate>().ReverseMap();
            CreateMap<CreateContentDto, Content>().ReverseMap();
            CreateMap<CreateChapterDto, Chapter>().ReverseMap();
        }
    }
}
