using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class Request<T>: RequestBase
    {
        public T Item { get; private set; }

        public Request(int userId)
        {
            base.UserId = userId;
        }
        public Request(T item)
        {
            Item = item;
        }
        public Request(T item,int userId)
        {
            Item = item;
            base.UserId = userId;
            User = new User(UserId);
        }
    }
}
