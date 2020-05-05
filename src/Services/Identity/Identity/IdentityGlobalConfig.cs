using App.SharedKernel;
using App.SharedKernel.Messaging.Email;
using Identity.Utility;
using Microsoft.Extensions.Configuration;
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
            HostModules = new System.Collections.Generic.Dictionary<IdentityEnums.Modules, string>() {
                {IdentityEnums.Modules.Identity,config[$"{nameof(HostModules)}:{nameof(IdentityEnums.Modules.Identity)}"] },
                 {IdentityEnums.Modules.Item,config[$"{nameof(HostModules)}:{nameof(IdentityEnums.Modules.Item)}"] },
                  {IdentityEnums.Modules.Order,config[$"{nameof(HostModules)}:{nameof(IdentityEnums.Modules.Order)}"] }
            };
            EmailConfig = new EmailConfig(config["Email:ApiKey"], config["Email:FromEmail"], config["Email:FromName"]);
        }
        public static JwtModel Jwt { get; set; }
    }
}
