using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Amazon.Order.EntityFrameworkCore;
using Amazon.Order.Tests.TestDatas;

namespace Amazon.Order.Tests
{
    public class OrderTestBase : AbpIntegratedTestBase<OrderTestModule>
    {
        public OrderTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<OrderDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<OrderDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<OrderDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<OrderDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<OrderDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<OrderDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<OrderDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<OrderDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
