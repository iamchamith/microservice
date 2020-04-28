using App.SharedKernel.ValueObjects;
using Identity.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Model.Entities
{
    [Table(nameof(UserInfo),Schema = AppConst.DEFAULT_SCHEMA)]
    public class UserInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string UserId { get; private set; }
        public virtual PersonName Name { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual string Email { get; private set; }
        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser IdentityUser { get; set; }

        public const string DefaultString = "-";
        public UserInfo()
        {
        }
        public UserInfo(string userid,string email)
        {
            Email = email;
            UserId = userid;
        }
        public UserInfo SetDefaultAddress() {
            Address = new Address(DefaultString, DefaultString, DefaultString);
            return this;
        }
        public UserInfo SetName(string name)
        {
            Name = new PersonName(DefaultString, DefaultString, DefaultString);
            return this;
        }
    }
}
