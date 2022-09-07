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
    internal class InventoryManager : BaseManager<Inventory, IInventoryRepository>, IInventoryManager
    {
        public InventoryManager(IInventoryRepository repository) : base(repository)
        {
        }
    }
}
