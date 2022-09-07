using Cvecara.Business.Managers.Contracts;
using Cvecara.Data.Entities;
using Cvecara.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Business.Managers
{
    internal class ItemManager : BaseManager<Item, IItemRepository>, IItemManager
    {
        public ItemManager(IItemRepository repository) : base(repository)
        {
        }
    }
}
