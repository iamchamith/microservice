using App.SharedKernel.Utilities;
using Identity.Model.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class UserSettingViewModel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), DataType(DataType.Text)]
        public string FirstName { get; set; }
        [StringLength(DataAnnotationsConst.NAME_LENGTH), DataType(DataType.Text)]
        public string MiddleName { get; set; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), DataType(DataType.Text)]
        public string Number { get; set; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), DataType(DataType.Text)]
        public string Street { get; set; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), DataType(DataType.Text)]
        public string City { get; set; }

        [Required, StringLength(DataAnnotationsConst.EMAIL_LENGTH), DataType(DataType.EmailAddress),
            RegularExpression(DataAnnotationsConst.EMAIL_REGEX)]
        public string Email { get; set; }
        [Required, StringLength(DataAnnotationsConst.PHONE_LENGTH), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public UserSettingViewModel()
        {

        }
        public UserSettingViewModel(IdentityUser identityUser, UserInfo userinfo)
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
