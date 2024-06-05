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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChapterController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateChapterDto>>> GetChapters()
        {
            var chapters = await _unitOfWork.Chapters.GetAll();
            var createChapterDto = _mapper.Map<IEnumerable<CreateChapterDto>>(chapters);
            return Ok(createChapterDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateChapterDto>> GetChapter(Guid id)
        {
            var chapter = await _unitOfWork.Chapters.GetById(id);

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
            await _unitOfWork.Chapters.Add(chapter);

            var createdChapterDto = _mapper.Map<CreateChapterDto>(chapter);

            return CreatedAtAction(nameof(GetChapter),
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
            await _unitOfWork.Chapters.Update(chapter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Chapter>> DeleteChapter(Guid id)
        {

            await _unitOfWork.Chapters.Delete(id);
            return NoContent(); ;
        }
    }
}
