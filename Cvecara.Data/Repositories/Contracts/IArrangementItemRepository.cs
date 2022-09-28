using Cvecara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Repositories.Contracts
{
    public interface IArrangementItemRepository : IBaseRepository<ArrangementItem>
    {
        void Remove(int arrangementId, int itemId);
    }
}
