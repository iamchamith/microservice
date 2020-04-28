using Abp.ObjectMapping;
using Abp.Runtime.Caching;

namespace App.SharedKernel.Application
{
    public interface IApplicationInjector
    {
        IObjectMapper Mapper { get; set; }
        ICache Cache { get; set; }
    }
}
