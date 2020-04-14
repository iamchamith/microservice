using System.Threading.Tasks;
using Amazon.Items.Web.Controllers;
using Shouldly;
using Xunit;

namespace Amazon.Items.Web.Tests.Controllers
{
    public class HomeController_Tests: ItemsWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
