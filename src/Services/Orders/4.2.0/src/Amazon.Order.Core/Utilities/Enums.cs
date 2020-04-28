namespace Amazon.Order.Utilities
{
    public class Enums
    {
        public enum ShippingProgress
        {
            Draft = 1,
            PendingToStart = 2,
            Processing = 3,
            Complete = 4
        }

        public enum PaymentDoneBy
        {
            Cash = 1,
            Card = 2,
            Coopon = 3
        }
    }
}
