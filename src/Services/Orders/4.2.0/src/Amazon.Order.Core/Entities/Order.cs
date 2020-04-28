using Abp.Domain.Entities;
using Abp.Events.Bus;
using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Amazon.Order.Utilities.Enums;

namespace Amazon.Order.Entities
{
    [Table(nameof(Order), Schema = OrderConsts.SCHEMA)]
    public class Order : Entity, IAggregateRoot
    {
        public virtual int CustomerId { get; private set; }
        public virtual decimal TotalPrice { get; private set; }
        public virtual decimal RemainingPayment { get; private set; }
        public virtual bool PaymentIsComplete { get; private set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual CustomerInfo Customer { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual DateTime CreatedDateTime { get; private set; }
        public virtual DateTime PaymentCompleteDateTime { get; private set; }
        [NotMapped]
        public ICollection<IEventData> DomainEvents { get; set; }

        public Order()
        {
        }
        public Order(CustomerInfo customer)
        {
            if (customer.IsDeleted)
                throw new BadRequestException("Customer is deleted".MakeThisRedable());
            CustomerId = customer.Id;
            PaymentIsComplete = false;
            CreatedDateTime = DateTime.UtcNow;
        }
        public Order SetShipping(Shipping shipping)
        {
            Shipping = shipping;
            return this;
        }
        public Order AddItem(int itemId, string name, int quantity, decimal unitPrice)
        {

            if (OrderItems.IsNullOrZero())
                OrderItems = new List<OrderItem>();
            var obj = new OrderItem(itemId, name, quantity, unitPrice);
            OrderItems.Add(obj);
            TotalPrice += obj.TotalPrice;
            RemainingPayment = TotalPrice - (Payments ?? new List<Payment>()).Sum(p => p.Amount);
            return this;
        }

        public Order UpdateShippingProgress(ShippingProgress shippingProgress)
        {
            if (Shipping.IsNull())
            {
                throw new NotFoundException($"shipping object not found for order id:-{Id}".MakeThisRedable());
            }

            return this;
        }
        public Order AddPayment(Payment payment)
        {
            if (Payments.IsNullOrZero())
                Payments = new List<Payment>();

            RemainingPayment -= payment.Amount;
            if (RemainingPayment == 0)
            {
                PaymentIsComplete = true;
                PaymentCompleteDateTime = DateTime.UtcNow;
            }
            if (RemainingPayment < 0)
                throw new BadRequestException("Invalid payment.".MakeThisRedable());

            Payments.Add(payment);
            return this;
        }
    }
}
