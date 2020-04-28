using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class RequestBase
    {
        public int UserId { get; protected set; }
        public User User { get; protected set; }
    }
}
