using Droos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepoBase<Content> Contentes { get; }
        IRepoBase<Chapter> Chapters { get; }

        int Complete();
       
    }
}
