using Cvecara.Business.Managers.Contracts;
using Cvecara.Data.Entities;
using Cvecara.Data.Repositories.Contracts;

namespace Cvecara.Business.Managers
{
    internal class ArrangementItemManager : BaseManager<ArrangementItem, IArrangementItemRepository>, IArrangementItemManager
    {
        public ArrangementItemManager(IArrangementItemRepository repository) : base(repository)
        {
        }

        public void Remove(int arrangementId, int itemId)
        {
            _repository.Remove(arrangementId, itemId);
        }
    }
}
