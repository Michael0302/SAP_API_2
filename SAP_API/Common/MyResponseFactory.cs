using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Mvc;

namespace SAP_API.Common
{
    public interface IMyResponseFactory : IResponseFactory<IActionResult, ErrorCodes>
    {
    }
    public class MyResponseFactory : IMyResponseFactory
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        public MyResponseFactory(IApiResponseFactory apiResponseFactory)
        {
            _apiResponseFactory = apiResponseFactory;
        }
        public IActionResult CreateOKResponse()
        {
            return new NoContentResult();
        }
        public IActionResult CreateOKResponse<T>(T data)
        {
            return new OkObjectResult(_apiResponseFactory.CreateOKResponse(data));
        }
        public IActionResult CreateErrorResponse(ErrorCodes code, string message = "")
        {
            int httpCode = (int)code / 100 % 1000;
            return new ObjectResult(_apiResponseFactory.CreateErrorResponse(code, message))
            {
                StatusCode = httpCode
            };
        }
    }
}
