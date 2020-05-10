namespace App.SharedKernel.Model
{
    public class Enums
    {
        public enum ExceptionHappenOn
        {
            None,
            Server,
            Web
        }

        public enum Modules { 
        
            None,
            Gateway,
            Identity,
            Item,
            Order
        }
    }
}
