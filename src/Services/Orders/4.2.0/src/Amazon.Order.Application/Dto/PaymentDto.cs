using Abp.Application.Services.Dto;
using System;
using static Amazon.Order.OrderEnums;

namespace Amazon.Order.Dto
{
    public class PaymentDto : EntityDto
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentDoneBy PaymentDoneBy { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
