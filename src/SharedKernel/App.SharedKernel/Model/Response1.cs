using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class Response<T>
    {
        public T Item { get; private set; }

        public Response(T item)
        {
            Item = item;
        }
    }
}
