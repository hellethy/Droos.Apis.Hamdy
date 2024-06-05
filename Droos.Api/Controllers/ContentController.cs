using AutoMapper;
using Droos.Api.Dtos;
using Droos.Models;
using Droos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Droos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateContentDto>>> GetContentes()
        {
            var contentes = await _unitOfWork.Contentes.GetAll();
            var createContentDto = _mapper.Map<IEnumerable<CreateContentDto>>(contentes);
            return Ok(createContentDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateContentDto>> GetContent(Guid id)
        {
            var content = await _unitOfWork.Contentes.GetById(id);

            if (content == null)
            {
                return NotFound();
            }
            var createContentDto = _mapper.Map<CreateContentDto>(content);
            return Ok(createContentDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateContentDto>> CreateContent(CreateContentDto createContentDto)
        {
            var content = _mapper.Map<Content>(createContentDto);
            await _unitOfWork.Contentes.Add(content);

            var createdContentDto = _mapper.Map<CreateContentDto>(content);

            return CreatedAtAction(nameof(GetContent),
                new
                {
                    contentId = createContentDto.ContentId,
                    name = createdContentDto.Name,
                    creationOn = createContentDto.CreatedOn,
                    examId = createContentDto.ExamId,
                    mcqId = createContentDto.McqId,
                    type= createContentDto.Type,
                    durationInSeconds = createContentDto.DurationInSeconds,
                    isFree = createContentDto.IsFree,
                    url = createContentDto.Url,
                    htmlText = createContentDto.HtmlText,
                },
                    createdContentDto
                );


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CreateContentDto>> Updatechapter(Guid id, CreateContentDto createContentDto)
        {

            if (id != createContentDto.ContentId)
            {
                return BadRequest();
            }
            var content = _mapper.Map<Content>(createContentDto);
            await _unitOfWork.Contentes.Update(content);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Content>> DeleteContent(Guid id)
        {

            await _unitOfWork.Contentes.Delete(id);
            return NoContent(); ;
        }
    }
}
