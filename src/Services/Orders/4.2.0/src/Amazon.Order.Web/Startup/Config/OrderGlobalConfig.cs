using App.SharedKernel;
using App.SharedKernel.Messaging.Email;
using Microsoft.Extensions.Configuration;

namespace Amazon.Order.Web.Startup.Config
{
    public class OrderGlobalConfig : GlobalConfig
    {
        public OrderGlobalConfig(IConfiguration config)
        {
            ConnectionString = config[nameof(ConnectionString)];

            HostModules = new System.Collections.Generic.Dictionary<OrderEnums.Modules, string>() {
                {OrderEnums.Modules.Identity,config[$"{nameof(HostModules)}:{nameof(OrderEnums.Modules.Identity)}"] },
                 {OrderEnums.Modules.Item,config[$"{nameof(HostModules)}:{nameof(OrderEnums.Modules.Item)}"] },
                  {OrderEnums.Modules.Order,config[$"{nameof(HostModules)}:{nameof(OrderEnums.Modules.Order)}"] }
            };
            EmailConfig = new EmailConfig(config["Email:ApiKey"], config["Email:FromEmail"], config["Email:FromName"]);
        }
    }
}
