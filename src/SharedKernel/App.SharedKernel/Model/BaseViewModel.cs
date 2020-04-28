namespace App.SharedKernel.Model
{
    public class BaseViewModel<T>
    {
        public T Id { get; set; }
    }
    public class BaseViewModel
    {
        public int Id { get; set; }
    }
}
