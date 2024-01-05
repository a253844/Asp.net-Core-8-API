using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static BlockAction.API.Controllers.WebTool;

namespace BlockAction.API.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation("Exception Filter Start。");

            
            var error = new ServerResponseInfo()
            {
                code = 404,
                message = context.Exception.Message,
                status = "failed",
                data = "",
            };

            context.Result = new JsonResult(error);
        }
    }
}
