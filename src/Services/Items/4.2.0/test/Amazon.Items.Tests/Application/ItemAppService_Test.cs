using Amazon.Items.Interface;
using App.SharedKernel.Model;
using System.Threading.Tasks;
using Xunit;

namespace Amazon.Items.Tests.Application
{
    public class ItemAppService_Test: ItemsTestBase
    {
        private readonly IItemAppService _itemAppService;
        public ItemAppService_Test(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        [Fact]
        public async Task GetItemById() {
          
            var output = await _itemAppService.GetItemById(new Request<int>(1));
            var x = output.Item;
        }
    }
}
