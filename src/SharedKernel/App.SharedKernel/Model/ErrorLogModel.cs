using static App.SharedKernel.Model.Enums;

namespace App.SharedKernel.Model
{
    public class ErrorLogModel
    {
        public int Id { get; set; }
        public string Exception { get; set; }
        public string BaseException { get; set; }
        public string RequestData { get; set; }
        public string StackTrace { get; set; }
        public bool IsSolve { get; set; }
        public ExceptionHappenOn ExceptionHappenOn { get; set; }

        public ErrorLogModel(System.Exception e, ExceptionHappenOn exceptionHappenOn = ExceptionHappenOn.Server, string requestData = "")
        {
            Exception = e.Message;
            BaseException = e.GetBaseException()?.Message;
            StackTrace = e.StackTrace;
            IsSolve = false;
            ExceptionHappenOn = exceptionHappenOn;
            RequestData = requestData;

        }
    }
}
