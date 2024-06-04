using Droos.Model.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Repositories.Interfaces
{
    public interface IBlobStorageRepo
    {


        public Task<string> UploadAsync(IFormFile file);
        public Task<Blob> DownloadAsync(string fileName);
        public void MoveFileAsync(string fileName, string destinationContainerName);
    }
}
