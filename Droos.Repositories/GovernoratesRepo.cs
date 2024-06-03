using Droos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Repositories
{
    public class GovernoratesRepo 
    {
      

        public  IEnumerable<Models.Governorate> GetGovernorates()
        {
            throw new NotImplementedException();
        }

        public Guid CreateGovernorates(Models.Governorate governorate)
        {
            throw new NotImplementedException();
        }
        public Guid UpdateGovernorates(Models.Governorate governorate)
        {
            throw new NotImplementedException();
        }
        public Guid DeactivateGovernorates(Guid GovernoratesId)
        {
            throw new NotImplementedException();
        }
    }
}

