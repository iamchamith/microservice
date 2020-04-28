using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class Request<T1,T2>: RequestBase
    {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }

        public Request(int userId)
        {
            base.UserId = userId;
            User = new User(UserId);
        }
        public Request(T1 item1,T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public Request(T1 item1,T2 item2,int userId)
        {
            Item1 = item1;
            Item2 = item2;
            UserId = userId;
            User = new User(UserId);
        }
    }
}
