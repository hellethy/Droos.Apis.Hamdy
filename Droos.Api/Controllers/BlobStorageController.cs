using Droos.Model.Models;
using Droos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Droos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly IBlobStorageRepo _blobStorageRepo;

        public BlobStorageController( IBlobStorageRepo blobStorageRepo)
        {
            _blobStorageRepo = blobStorageRepo;
        }

        [HttpPost("Upload")]finish endpointc
        public async Task<ActionResult<Blob>> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or not selected.");
            }

            var fileUri = await _blobStorageRepo.UploadAsync(file);
            return Ok(fileUri);
        }

        [HttpGet("download/{fileName}")]
        public async Task<ActionResult<Blob>> DownloadFile(string fileName)
        {

            var blob = await _blobStorageRepo.DownloadAsync(fileName);

            if (blob == null)
            {
                return NotFound();
            }

            return Ok(blob);
        }
    }
}
