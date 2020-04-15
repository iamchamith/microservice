using Abp.Application.Services.Dto;
using App.SharedKernel.ValueObjects;

namespace Amazon.Order.Dto
{
    public class CustomerInfoDto : EntityDto
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public PersonName Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
