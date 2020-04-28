using System;
using Amazon.Items.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using App.SharedKernel.Model;
using Amazon.Items.Dto;
using Amazon.Items.Web.ViewModel;
using App.SharedKernel.Attribute;

namespace Amazon.Items.Web.Api
{
    [Route(ROUTER_PREFIX_V1)]
    public class ItemApiController : ItemBaseApiController
    {
        private IBrandAppService _brandAppService { get; }
        private IItemAppService _itemAppService { get; }

        public ItemApiController(IBrandAppService brandAppService, IItemAppService itemAppService)
        {
            _brandAppService = brandAppService;
            _itemAppService = itemAppService;
        }
        #region brands
        [Route("brands"), HttpGet]
        public async Task<IActionResult> GetBrands(string searchTerm, string orderBy, bool isAsc, int skip, int take)
        {
            Request<Search> request = null;
            try
            {
                request = Request(Search(searchTerm, orderBy, isAsc, skip, take));
                var result = await _brandAppService.GetBrands(request);
                return Ok(DtoToVm<BrandDto, BrandViewModel>(result));
            }
            catch (Exception e)
            {
                return await HandleException(e, request);
            }
        }

        [Route("brands/keyvalues"), HttpGet]
        public async Task<IActionResult> GetBrandsKeyValuePair()
        {
            try
            {
                var result = await _brandAppService.GetBrandsKeyValuePair(Request(0));
                return Ok(result);
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
        #endregion
        #region items
        [Route("items/{id:int}"), HttpGet]
        public async Task<IActionResult> GetItemById(int id)
        {

            try
            {
                var response = await _itemAppService.GetItemById(Request(id));
                return Ok(DtoToVm<ItemDto, ItemViewModel>(response));
            }
            catch (Exception e)
            {
                return await HandleException(e, id);
            }
        }
        [Route("items"), HttpGet]
        public async Task<IActionResult> GetItems(string searchTerm, string orderTerms, int skip, int take)
        {
            Request<Search> request = null;
            try
            {
                request = Request(Search(searchTerm, orderTerms, skip, take));
                var result = await _itemAppService.GetItems(request);
                return Ok(DtoToVm<ItemDto, ItemViewModel>(result));
            }
            catch (Exception e)
            {
                return await HandleException(e, request);
            }
        }
        #endregion

    }
}
