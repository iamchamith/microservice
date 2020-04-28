using Identity.Model.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class UserSettingViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public UserSettingViewModel(IdentityUser identityUser,UserInfo userinfo)
        {
            Id = userinfo.Id;
            UserId = userinfo.UserId;
            FirstName = userinfo.Name.FirstName;
            MiddleName = userinfo.Name.MiddleName;
            Number = userinfo.Address.Number;
            Street = userinfo.Address.Street;
            City = userinfo.Address.City;
            Email = userinfo.Email;
            PhoneNumber = userinfo.PhoneNumber;
            TwoFactorEnabled = identityUser.TwoFactorEnabled;
        }
    }
}
