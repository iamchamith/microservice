using App.SharedKernel;

namespace Amazon.Items.Web.Startup.Config
{
    public class GlobalConfigConfig
    {
        public static void Register()
        {

            GlobalConfig.ConnectionString = "Server=DESKTOP-LE44UH9; Database=Amazon; Trusted_Connection=True;";
            GlobalConfig.Environment = "dev";
            GlobalConfig.Host = "http://localhost:5000";
        }
    }
}
