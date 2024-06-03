using Droos.Model.Context;
using Droos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Repositories.Interfaces
{
    public class ChapterRepo : RepoBase<Chapter>, IChapterRepo
    {
        public ChapterRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
