using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class Request<T1, T2, T3> : RequestBase
    {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }

        public T3 Item3 { get; private set; }
        public Request(int userId)
        {
            base.UserId = userId;
        }
        public Request(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
        public Request(T1 item1, T2 item2, T3 item3, int userId)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            UserId = userId;
        }
    }
}
