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
    public class ChapterController : ControllerBase
    {
        private readonly IRepoBase<Chapter> _repoBase;
        private readonly IMapper _mapper;

        public ChapterController(IRepoBase<Chapter> repoBase, IMapper mapper)
        {
            _repoBase = repoBase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateChapterDto>>> GetChapters()
        {
            var chapters = await _repoBase.GetAll();
            var createChapterDto = _mapper.Map<IEnumerable<CreateChapterDto>>(chapters);
            return Ok(createChapterDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateChapterDto>> GetChapterById(Guid id)
        {
            var chapter = await _repoBase.GetById(id);

            if (chapter == null)
            {
                return NotFound();
            }
            var createChapterDto = _mapper.Map<CreateChapterDto>(chapter);
            return Ok(createChapterDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateChapterDto>> CreateChapter(CreateChapterDto createChapterDto)
        {
            var chapter = _mapper.Map<Chapter>(createChapterDto);
            await _repoBase.Add(chapter);

            var createdChapterDto = _mapper.Map<CreateChapterDto>(chapter);

            return CreatedAtAction(nameof(GetChapterById),
                new
                {
                    chapterId = createChapterDto.ChapterId,
                    name = createdChapterDto.Name,
                    creationOn = createChapterDto.CreatedOn
                },
                    createdChapterDto
                );


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CreateChapterDto>> UpdateChapter(Guid id, CreateChapterDto createChapterDto)
        {

            if (id != createChapterDto.ChapterId)
            {
                return BadRequest();
            }
            var chapter = _mapper.Map<Chapter>(createChapterDto);
            await _repoBase.Update(chapter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Chapter>> DeleteChapter(Guid id)
        {

            await _repoBase.Delete(id);
            return NoContent(); ;
        }
    }
}
