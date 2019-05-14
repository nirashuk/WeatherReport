using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Model;

namespace Weather
{
    /// <summary>  
    /// This class is used for handle the custom exception in the application level.  
    /// </summary>  
    public class CustomExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpResponse httpResponse = context.HttpContext.Response;
            httpResponse.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(
                new ErrorDetails
                {
                    Message = context.Exception.Message
                });

            httpResponse.WriteAsync(result);
        }
    }
}
