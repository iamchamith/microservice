using Abp.Domain.Entities;
using App.SharedKernel.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Order.Entities
{
    [Table(nameof(PaymentInfo), Schema = OrderConsts.SCHEMA)]
    public class PaymentInfo : Entity
    {
        public virtual int CustomerId { get; private set; }
        [Required,StringLength(DataAnnotationsConst.NAME_LENGTH)]
        public virtual string Name { get; private set; }
        [Required, StringLength(DataAnnotationsConst.IDENTITY_LENGTH)]
        public virtual string CardNumber { get; private set; }
        public virtual DateTime ExpiredOn { get; private set; }
        [Required]
        public virtual int CSV { get; private set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual CustomerInfo Customer { get; set; }

        public PaymentInfo(int customerId,string name,string cardNumber,DateTime expireOn,int csv)
        {
            CustomerId = customerId;
            Name = name;
            CardNumber = cardNumber;
            ExpiredOn = expireOn;
            CSV = csv;
        }
        public PaymentInfo Update(string name, string cardNumber, DateTime expireOn, int csv)
        {
            Name = name;
            CardNumber = cardNumber;
            ExpiredOn = expireOn;
            CSV = csv;
            return this;
        }
    }
}
