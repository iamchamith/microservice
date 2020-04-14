using Abp.ObjectMapping;

namespace App.SharedKernel.Application
{
    public interface IApplicationInjector
    {
        IObjectMapper Mapper { get; set; }
    }
}
