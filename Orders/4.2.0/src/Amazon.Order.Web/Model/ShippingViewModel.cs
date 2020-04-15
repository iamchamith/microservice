using App.SharedKernel.Model;
using App.SharedKernel.ValueObjects;
using static Amazon.Order.Utilities.Enums;

namespace Amazon.Order.Web.Model
{
    public class ShippingViewModel : BaseViewModel
    {
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ShippingProgress ShippingProgress { get; set; }
    }
}
