namespace App.SharedKernel.Model
{
    public class User
    {
        public int UserId { get; private set; }

        public User(int userid)
        {
            UserId = userid;
        }
    }
}
