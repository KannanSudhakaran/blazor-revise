using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo03Exceptions.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new { filtererror = context.Exception.Message })
            {
                StatusCode = 500
            };
            // Optionally log context.Exception here
        }
    }
}
