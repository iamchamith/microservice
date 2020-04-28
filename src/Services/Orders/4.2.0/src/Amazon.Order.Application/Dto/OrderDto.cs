using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace Amazon.Order.Dto
{
    public class OrderDto : EntityDto
    {
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal RemainingPayment { get; set; }
        public bool PaymentIsComplete { get; set; }
        public ShippingDto Shipping { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public List<PaymentDto> Payments { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime PaymentCompleteDateTime { get; set; }
    }
}
