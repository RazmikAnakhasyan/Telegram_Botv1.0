using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Shared.Models.Banks;
using CodeFirst.Models;
using Shared.Models.Rates;

namespace DataAccess.Repository
{
   public interface IBankRepository
    {

        public IEnumerable<Rates> All();
    }
}
