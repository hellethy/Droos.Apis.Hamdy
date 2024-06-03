using Droos.Model.Context;
using Droos.Models;
using Droos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Repositories
{
    public class ContentRepo : RepoBase<Content>, IContentRepo
    {
        public ContentRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
