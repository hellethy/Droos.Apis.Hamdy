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
        private readonly IRepoBase<Content> _repoBase;
        private readonly IMapper _mapper;

        public ContentController(IRepoBase<Content> repoBase, IMapper mapper)
        {
            _repoBase = repoBase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateContentDto>>> GetContentes()
        {
            var contentes = await _repoBase.GetAll();
            var createContentDto = _mapper.Map<IEnumerable<CreateContentDto>>(contentes);
            return Ok(createContentDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateContentDto>> GetContentById(Guid id)
        {
            var content = await _repoBase.GetById(id);

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
            await _repoBase.Add(content);

            var createdContentDto = _mapper.Map<CreateContentDto>(content);

            return CreatedAtAction(nameof(GetContentById),
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
            await _repoBase.Update(content);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Content>> DeleteContent(Guid id)
        {

            await _repoBase.Delete(id);
            return NoContent(); ;
        }
    }
}
