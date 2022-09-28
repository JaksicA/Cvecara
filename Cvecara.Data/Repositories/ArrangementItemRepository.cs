using Cvecara.Data.Data;
using Cvecara.Data.Entities;
using Cvecara.Data.Repositories.Contracts;
using System.Linq;

namespace Cvecara.Data.Repositories
{
    internal class ArrangementItemRepository : BaseRepository<ArrangementItem>, IArrangementItemRepository
    {
        public ArrangementItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Remove(int arrangementId, int itemId)
        {
            _context.Remove(GetFirst(e => e.ArrangementId == arrangementId && e.ItemId == itemId));
            _context.SaveChanges();
        }
    }
}
