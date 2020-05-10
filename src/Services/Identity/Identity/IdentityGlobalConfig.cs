using App.SharedKernel;
using App.SharedKernel.Messaging.Email;
using Identity.Utility;
using Microsoft.Extensions.Configuration;
using App.SharedKernel.Model;
namespace Identity
{
    public class IdentityGlobalConfig : GlobalConfig
    {
        public IdentityGlobalConfig(IConfiguration config)
        {
            ConnectionString = config[nameof(ConnectionString)];
            Jwt = new JwtModel
            {
                Issue = config[$"{nameof(Jwt)}:{nameof(JwtModel.Issue)}"],
                Key = config[$"{nameof(Jwt)}:{nameof(JwtModel.Key)}"]
            };
            HostModules = new System.Collections.Generic.Dictionary<Enums.Modules, string>() {
               {Enums.Modules.Gateway,config[$"{nameof(HostModules)}:{nameof(Enums.Modules.Gateway)}"] },
                {Enums.Modules.Identity,config[$"{nameof(HostModules)}:{nameof(Enums.Modules.Identity)}"] },
                 {Enums.Modules.Item,config[$"{nameof(HostModules)}:{nameof(Enums.Modules.Item)}"] },
                  {Enums.Modules.Order,config[$"{nameof(HostModules)}:{nameof(Enums.Modules.Order)}"] }
            };
            EmailConfig = new EmailConfig(config["Email:ApiKey"], config["Email:FromEmail"], config["Email:FromName"]);
        }
        public static JwtModel Jwt { get; set; }
    }
}
