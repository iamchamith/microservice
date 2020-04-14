﻿using System.Threading.Tasks;
using Amazon.Order.Web.Controllers;
using Shouldly;
using Xunit;

namespace Amazon.Order.Web.Tests.Controllers
{
    public class HomeController_Tests: OrderWebTestBase
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
