using App.SharedKernel;
using App.SharedKernel.Messaging.Email;
using Microsoft.Extensions.Configuration;

namespace Amazon.Items.Web.Startup.Config
{
    public class ItemGlobalConfig : GlobalConfig
    {
        public ItemGlobalConfig(IConfiguration config)
        {
            ConnectionString = config[nameof(ConnectionString)];
           
            HostModules = new System.Collections.Generic.Dictionary<ItemEnums.Modules, string>() {
                {ItemEnums.Modules.Identity,config[$"{nameof(HostModules)}:{nameof(ItemEnums.Modules.Identity)}"] },
                 {ItemEnums.Modules.Item,config[$"{nameof(HostModules)}:{nameof(ItemEnums.Modules.Item)}"] },
                  {ItemEnums.Modules.Order,config[$"{nameof(HostModules)}:{nameof(ItemEnums.Modules.Order)}"] }
            };
            EmailConfig = new EmailConfig(config["Email:ApiKey"], config["Email:FromEmail"], config["Email:FromName"]);
        }
    }
}
