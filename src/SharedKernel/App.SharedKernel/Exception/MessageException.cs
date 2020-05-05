namespace App.SharedKernel.Exception
{
    public class MessageException : System.Exception
    {
        public MessageException(string message) : base(message)
        {
        }
        public MessageException(System.Exception exception) :base("inner exception",exception)
        {
        }
    }
}
