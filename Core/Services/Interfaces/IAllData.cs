using htmlWrapDemo;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IAllData
    {
        void BulknInsert(List<DataAccess.Models.Rate> currency);
    }
}
