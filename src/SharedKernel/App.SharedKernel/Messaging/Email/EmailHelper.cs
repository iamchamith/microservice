namespace App.SharedKernel.Messaging.Email
{
    public class EmailHelper
    {
        public static string AddParagraph(string paragraph)
        {
            return $"<p>{paragraph}</p>";
        }
        public static string AddNewLine() {
            return "<Br/>";
        }
        public static string AddLink(string url, string caption)
        {
            return $"<a href='{url}' targer='_blank'>{caption}</a>";
        }
    }
}
