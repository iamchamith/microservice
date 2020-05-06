using Abp.Domain.Entities;
using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using App.SharedKernel.Utilities;
using App.SharedKernel.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Amazon.Order.OrderEnums;

namespace Amazon.Order.Entities
{
    [Table(nameof(Shipping), Schema = OrderConsts.SCHEMA)]
    public class Shipping : Entity
    {
        public virtual Address Address { get; private set; }
        [Required, StringLength(DataAnnotationsConst.PHONE_LENGTH)]
        public virtual string Phone { get; private set; }
        [Required, StringLength(DataAnnotationsConst.EMAIL_LENGTH)]
        public virtual string Email { get; private set; }
        public virtual ShippingProgress ShippingProgress { get; private set; }
        public Shipping()
        {
        }
        public Shipping(Address address, string phone, string email)
        {
            if (phone.IsValidPhoneNumber())
                throw new BadRequestException("invalid phone number".MakeThisRedable());
            Address = address;
            Phone = phone;
            Email = email;
        }

        public Shipping UpdateShippingProgress(ShippingProgress shippingProgress)
        {
            ShippingProgress = shippingProgress;
            return this;
        }
    }
}
