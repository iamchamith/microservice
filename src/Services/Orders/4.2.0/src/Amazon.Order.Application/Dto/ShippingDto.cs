using Abp.Application.Services.Dto;
using App.SharedKernel.ValueObjects;
using static Amazon.Order.Utilities.Enums;

namespace Amazon.Order.Dto
{
    public class ShippingDto : EntityDto
    {
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ShippingProgress ShippingProgress { get; set; }
    }
}
