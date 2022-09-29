using Cvecara.Business.Managers.Contracts;
using Cvecara.Data.Entities;
using Cvecara.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cvecara.Business.Managers
{
    internal class ArrangementItemManager : BaseManager<ArrangementItem, IArrangementItemRepository>, IArrangementItemManager
    {
        private readonly IArrangementManager _arrangementManager;
        private readonly IItemManager _itemManager;

        public ArrangementItemManager(IArrangementItemRepository repository, 
            IArrangementManager arrangementManager,
            IItemManager itemManager) : base(repository)
        {
            _arrangementManager = arrangementManager;
            _itemManager = itemManager;
        }

        public override void Add(ArrangementItem entity)
        {
            //var arrangement = _arrangementManager.GetFirst(e => e.Id == entity.Id);
            base.Add(entity);
            PopulateArrangementItem(entity);
            CalculatePrice(entity);
            _arrangementManager.Update(entity.Arrangement);
        }

        public override void Update(ArrangementItem entity)
        {
            base.Update(entity);
            PopulateArrangementItem(entity);
            CalculatePrice(entity);
            _arrangementManager.Update(entity.Arrangement);
        }

        public void Remove(int arrangementId, int itemId)
        {
            var arrangementItem = _repository.GetFirst(e => e.ArrangementId == arrangementId && e.ItemId == itemId);
            _repository.Remove(arrangementId, itemId);
            PopulateArrangementItem(arrangementItem);
            CalculatePrice(arrangementItem);
            _arrangementManager.Update(arrangementItem.Arrangement);
        }

        private void PopulateArrangementItem(ArrangementItem arrangementItem)
        {
            arrangementItem.Arrangement = _arrangementManager.GetFirst(e => e.Id == arrangementItem.ArrangementId);
            arrangementItem.Item = _itemManager.GetFirst(e => e.Id == arrangementItem.ItemId);
        }

        private void CalculatePrice(ArrangementItem arrangementItem)
        {
            var arrangementItems = _repository.Get(e => e.ArrangementId == arrangementItem.ArrangementId, 
                new List<Expression<Func<ArrangementItem, object>>> 
                {
                    e => e.Item
                });

            arrangementItem.Arrangement.Price = Constants.DecorationPrice + 
                arrangementItems.Select(e => e.Item.Price * e.Quantity).Sum();
        }
    }
}
