using Abp.Domain.Entities;
using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Amazon.Order.OrderEnums;

namespace Amazon.Order.Entities
{
    [Table(nameof(Payment), Schema = OrderConsts.SCHEMA)]
    public class Payment : Entity
    {
        public virtual int OrderId { get; private set; }
        public virtual decimal Amount { get; private set; }
        public virtual PaymentDoneBy PaymentDoneBy { get; private set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public virtual DateTime CreateOn { get; private set; }
        public Payment()
        {
        }
        public Payment(decimal amount,PaymentDoneBy paymentDoneBy)
        {
            if (!amount.IsValidAmount()) {
                throw new BadRequestException($"invalid amount {amount}".MakeThisRedable());
            }
            Amount = amount;
            PaymentDoneBy = paymentDoneBy;
            CreateOn = DateTime.UtcNow;
        }
    }
}
