using Abp.Domain.Entities;
using App.SharedKernel.Utilities;
using App.SharedKernel.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Order.Entities
{
    [Table(nameof(CustomerInfo), Schema = OrderConsts.SCHEMA)]
    public class CustomerInfo : Entity, ISoftDelete
    {
        [Required, StringLength(DataAnnotationsConst.PHONE_LENGTH), Phone]
        public virtual string Phone { get; private set; }
        [Required, StringLength(DataAnnotationsConst.EMAIL_LENGTH), EmailAddress]
        public virtual string Email { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual PersonName Name { get; private set; }
        public bool IsDeleted { get; set; }

        public CustomerInfo()
        {
        }
        public CustomerInfo(int id, PersonName name, string phone, string email, Address address)
        {
            Id = id;
            Phone = phone;
            Email = email;
            Address = address;
            Name = name;
        }

        public CustomerInfo Update(PersonName name, string phone, string email, Address address) {
            Phone = phone;
            Email = email;
            Address = address;
            Name = name;
            return this;
        }
    }
}
