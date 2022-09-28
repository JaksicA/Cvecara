using Cvecara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Business.Managers.Contracts
{
    public interface IArrangementItemManager : IBaseManager<ArrangementItem>
    {
        void Remove(int arrangementId, int itemId);
    }
}
