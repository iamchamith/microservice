using System;
using System.Collections.Generic;
using System.Text;
using Abp.ObjectMapping;

namespace App.SharedKernel.Application
{
    public class ApplicationInjector : IApplicationInjector
    {
        public IObjectMapper Mapper { get; set; }
        public ApplicationInjector(IObjectMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
