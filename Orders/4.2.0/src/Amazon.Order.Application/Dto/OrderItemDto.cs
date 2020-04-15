using Abp.Application.Services.Dto;

namespace Amazon.Order.Dto
{
    public class OrderItemDto : EntityDto
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
