using App.SharedKernel.Model;
using System;
using System.Collections.Generic;
namespace Amazon.Order.Web.Model
{
    public class OrderViewModel : BaseViewModel
    {
        public decimal TotalPrice { get; set; }
        public decimal RemainingPayment { get; set; }
        public bool PaymentIsComplete { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public List<PaymentViewModel> Payments { get; set; }
        public virtual ShippingViewModel Shipping { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime PaymentCompleteDateTime { get; set; }
    }
}
