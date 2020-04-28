using App.SharedKernel.Exception;
namespace App.SharedKernel.Extension
{
    public static class ObjectExtension
    {
        public static T ThrowExceptionIfNull<T>(this T obj,int id=0) where T : class
        {
            if (obj.IsNull())
            {
                throw new NotFoundException($"{typeof(T)} not found {(id.Is(0) ? "." : $"for id=={id}")}");
            }
            return obj;
        }

        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
    }
}
