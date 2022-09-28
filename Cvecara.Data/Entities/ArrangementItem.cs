using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Entities
{
    public class ArrangementItem : IEntity
    {
        public int ArrangementId { get; set; }
        public int ItemId { get; set; }
        public Arrangement Arrangement { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        [NotMapped] public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
