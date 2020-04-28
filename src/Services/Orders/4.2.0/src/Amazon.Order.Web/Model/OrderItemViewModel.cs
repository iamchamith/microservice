using App.SharedKernel.Model;

namespace Amazon.Order.Web.Model
{
    public class OrderItemViewModel : BaseViewModel
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
