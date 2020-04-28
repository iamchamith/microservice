using App.SharedKernel.Model;
using System;
using static Amazon.Order.Utilities.Enums;

namespace Amazon.Order.Web.Model
{
    public class PaymentViewModel : BaseViewModel
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentDoneBy PaymentDoneBy { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
