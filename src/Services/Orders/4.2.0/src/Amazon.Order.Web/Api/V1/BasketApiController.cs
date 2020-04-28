using Amazon.Order.Dto;
using Amazon.Order.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amazon.Order.Web.Api.V1
{
    [Route(ROUTER_PREFIX_V1+"/baskets")]
    public class BasketApiController : OrderBaseApiController
    {
        private readonly IBasketAppService _basketAppService;
        public BasketApiController(IBasketAppService basketAppService)
        {
            _basketAppService = basketAppService;
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody] BasketModel model)
        {
            try
            {
                await _basketAppService.AddToBasket(Request(model));
                return Ok();
            }
            catch (Exception e)
            {
                return await HandleException(e, model);
            }          
        }
        [HttpDelete,Route("clears")]
        public async Task<IActionResult> ClearBusketByUserId()
        {
            try
            {
                await _basketAppService.ClearBusketByUserId(Request(0));
                return Ok();
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ReadItemsByUserId()
        {
            try
            {
                var result = await _basketAppService.ReadItemsByUserId(Request(0));
                return Ok(result);
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
        [HttpPut,Route("{id:int}")]
        public async Task<IActionResult> RemoveBasket(int id)
        {
            try
            {
                await _basketAppService.RemoveBasket(Request(id));
                return Ok();
            }
            catch (Exception e)
            {
                return await HandleException(e, id);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] BasketModel model)
        {
            try
            {
                await _basketAppService.UpdateBasket(Request(model));
                return Ok();
            }
            catch (Exception e)
            {
                return await HandleException(e, model);
            }
        }
    }
}
