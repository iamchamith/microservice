using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace App.SharedKernel.Utilities
{
    class JsonPrivateSetterResolver: DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            if (member is PropertyInfo pi)
            {
                prop.Readable = (pi.GetMethod != null);
                prop.Writable = (pi.SetMethod != null);
            }
            return prop;
        }
    }
}
