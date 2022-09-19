using Cvecara.Data.Data;
using Cvecara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Repositories.Contracts
{
    internal class ArrangementRepository : BaseRepository<Arrangement>, IArrangementRepository
    {
        public ArrangementRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
