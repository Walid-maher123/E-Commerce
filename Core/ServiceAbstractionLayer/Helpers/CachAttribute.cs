using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstractionLayer.IServices;

namespace ServiceAbstractionLayer.Helpers
{
    public class CachAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeOfSecond;

        public CachAttribute(int TimeOfSecond)
        {
            _timeOfSecond = TimeOfSecond;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           var cachService = context.HttpContext.RequestServices.GetRequiredService<IResponseCachService>();


            var CachKey = GenerateCachKey(context.HttpContext.Request);

             var GetData = await cachService.GetCachedData(CachKey);
            if(!string.IsNullOrEmpty(GetData) )
            {
                var content = new ContentResult()
                {
                    Content = GetData,
                    ContentType = "application/json",
                    StatusCode = 200
                };

                context.Result = content;
                return;
            }


            var ExcuteEndPoint = await  next.Invoke();

            if(ExcuteEndPoint.Result is OkObjectResult result)
            {
                await cachService.CachData(CachKey, result.Value,TimeSpan.FromSeconds(_timeOfSecond));
                return;
            }

        }

        private string GenerateCachKey(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();

            KeyBuilder.Append(request.Path);

            foreach(var (key,value) in request.Query.OrderBy(x=>x.Key))
                KeyBuilder.Append($"|{key}-{value}");

            return KeyBuilder.ToString();
        }
    }
}
