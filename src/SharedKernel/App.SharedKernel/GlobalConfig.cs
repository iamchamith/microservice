using App.SharedKernel.Messaging.Email;
using App.SharedKernel.Model;
using System.Collections.Generic;

namespace App.SharedKernel
{
    public class GlobalConfig
    {
        public static Dictionary<Enums.Modules, string> HostModules { get; set; }
        public static string Environment { get; set; }
        public static string ConnectionString { get; set; }
        public static EmailConfig EmailConfig { get; set; }
    }
}
