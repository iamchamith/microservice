using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Amazon.Items.EntityFrameworkCore;
using Amazon.Items.Tests.TestDatas;

namespace Amazon.Items.Tests
{
    public class ItemsTestBase : AbpIntegratedTestBase<ItemsTestModule>
    {
        public ItemsTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<ItemsDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ItemsDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<ItemsDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ItemsDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<ItemsDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ItemsDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<ItemsDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ItemsDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
