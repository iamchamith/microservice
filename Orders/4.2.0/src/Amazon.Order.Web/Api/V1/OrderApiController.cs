using Amazon.Order.Dto;
using Amazon.Order.Interface;
using Amazon.Order.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Order.Web.Api
{
    [Route(ROUTER_PREFIX_V1)]
    public class OrderApiController : OrderBaseApiController
    {
        private readonly IOrderAppService _orderAppService;
        public OrderApiController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost, Route("orders")]
        public async Task<IActionResult> CrateOrder([FromBody]OrderViewModel model)
        {
            try
            {
                var result = await _orderAppService.CreateOrder(Request(ObjectMapper.Map<OrderDto>(model)));
                return Ok(base.DtoToVm<OrderDto, OrderViewModel>(result));
            }
            catch (Exception e)
            {
                return await HandleException(e, model);
            }
        }
        [HttpGet, Route("orders/{id:int}")]
        public async Task<IActionResult> ReadOrderByOrderId(int id)
        {
            try
            {
                var result = await _orderAppService.ReadOrderByOrderId(Request(id));
                return Ok(base.DtoToVm<OrderDto, OrderViewModel>(result));
            }
            catch (Exception e)
            {
                return await HandleException(e, id);
            }
        }
        [HttpGet, Route("orders/mine")]
        public async Task<IActionResult> ReadOrderByOrderId()
        {
            try
            {
                var result = await _orderAppService.ReadOrdersByCustomer(Request(0));
                return Ok(base.DtoToVm<List<OrderDto>, List<OrderViewModel>>(result));
            }
            catch (Exception e)
            {
                return await HandleException(e, UserId);
            }
        }
    }
}
