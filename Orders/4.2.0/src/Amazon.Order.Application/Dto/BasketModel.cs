using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using App.SharedKernel.Model;
using System;

namespace Amazon.Order.Dto
{
    [Serializable]
    public class BasketModel
    {
        public int UserId { get; private set; }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; private set; }

        public BasketModel SetUser(User user) {
            UserId = user.UserId;
            return this;
        }

        public BasketModel CalculateTotalPrice()
        {
            TotalAmount = Quantity * ItemUnitPrice;
            return this;
        }

        public BasketModel AddMoreItems(BasketModel item)
        {
            if (item.ItemId.Is(ItemId))
                Quantity += item.Quantity;
            else
                throw new BadRequestException("Invalid Operation");
            return this;
        }

        public BasketModel Update(int quantity) {
            Quantity = quantity;
            return this;
        }
    }
}
