namespace Identity.Utility
{
    public class ViewMessage
    {
        public bool? IsSuccess { get; set; }
        public string Message { get; set; }
        public ViewMessage()
        {
        }
        public ViewMessage(bool isSuccess,string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
