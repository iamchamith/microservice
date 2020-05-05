using Abp.AspNetCore.Mvc.Controllers;
using App.SharedKernel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using App.SharedKernel.Exception;
using App.SharedKernel.Utilities;
using System.Collections.Generic;

namespace App.SharedKernel.Api
{
    public class BaseApiController : AbpController
    {
        protected Request<T> Request<T>(T item)
        {
            return new Request<T>(item);
        }

        protected Search Search(string searchterm, string orderBy, bool isAsc, int skip, int take)
        {
            return new Search()
                .SetPaging(skip, take)
                .SetOrderBy(orderBy, isAsc)
                .SetSearchTerm(searchterm);
        }
        protected Search Search(string searchterm, string orderByRequest, int skip, int take)
        {
            return new Search()
                .SetPaging(skip, take)
                .SetOrderBy(orderByRequest)
                .SetSearchTerm(searchterm);
        }
        protected int UserId { get; set; }

        protected Response<List<TVm>, PageList> DtoToVm<TDto, TVm>(Response<List<TDto>, PageList> response)
        {

            var vm = ObjectMapper.Map<List<TVm>>(response.Item1);
            var pl = response.Item2;
            return new Response<List<TVm>, PageList>(vm, pl);
        }
        protected Response<TVm> DtoToVm<TDto, TVm>(Response<TDto> response)
        {
            var vm = ObjectMapper.Map<TVm>(response.Item);
            return new Response<TVm>(vm);
        }

        protected async Task<IActionResult> HandleException(System.Exception exception, int requestObject)
        {
            return await HandleException<dynamic>(exception, new { requestObject });
        }
        protected async Task<IActionResult> HandleException(System.Exception exception)
        {
            return await HandleException<string>(exception, null);
        }

        protected async Task<IActionResult> HandleException<T>(System.Exception exception, T requestObject = null) where T : class
        {
            if (exception is BadRequestException)
                return StatusCode(400, exception.Message);
            else if (exception is UnAuthorizedException)
                return StatusCode(403, exception.Message);
            else if (exception is UnAuthonticatedException)
                return StatusCode(401, exception.Message);
            else if (exception is NotFoundException)
                return StatusCode(404, exception.Message);
            else if (exception is NotFoundException)
                return StatusCode(404, exception.Message);
            else if (exception is EatException)
                return StatusCode(200, exception.Message);
            else
            {
                var requestObjectString = "";
                try
                {
                    if (requestObject != null)
                        requestObjectString = requestObject.ToString();
                }
                catch (System.Exception)
                {
                    requestObjectString = "Error happen when casting";
                }

                await new ErroLogService(new DbConnector()).DoErrorLog(exception, requestObjectString);
                return StatusCode(500, GlobalConfig.Environment.Equals("dev") ? exception.Message : "Internal server Error");
            }
        }
    }
}
