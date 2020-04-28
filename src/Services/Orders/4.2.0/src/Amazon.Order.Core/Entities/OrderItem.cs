using Abp.Domain.Entities;
using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Order.Entities
{
    [Table(nameof(OrderItem), Schema = OrderConsts.SCHEMA)]
    public class OrderItem : Entity
    {
        public virtual int OrderId { get; private set; }
        public virtual int ItemId { get; private set; }
        public virtual string Name { get; private set; }
        public virtual int Quantity { get; private set; }
        public virtual decimal UnitPrice { get; private set; }

        [NotMapped]
        public decimal TotalPrice { get; private set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        public OrderItem()
        {
        }
        public OrderItem(int itemId, string name, int quantity, decimal unitPrice)
        {
            if (quantity.IsZeroOrNegative())
                throw new BadRequestException($"Invalid quantity {quantity}".MakeThisRedable());
            if (unitPrice.IsValidAmount())
                throw new BadRequestException($"Invalid Amount".MakeThisRedable());
            ItemId = itemId;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = Quantity * UnitPrice;
        }
    }
}
