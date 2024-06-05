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
    public class UnitOfwork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IRepoBase<Content> Contentes { get; private set; }
        public IRepoBase<Chapter> Chapters { get; private set; }
        public UnitOfwork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Contentes = new RepoBase<Content>(_dbContext);
            Chapters = new RepoBase<Chapter>(_dbContext);
        }

        public int Complete()
        {
          return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
    
}
