namespace Identity.Utility
{
    public class MvcHelper
    {
        public static string GetComponentPath(string folder,string name) {

            return $"{AppConst.COMPONENT}/{folder}/{name}.cshtml";
        }
    }
}
