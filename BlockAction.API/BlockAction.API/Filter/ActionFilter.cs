using BlockAction.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlockAction.API.Filter
{
    public class ActionFilter : IActionFilter
    {
        private readonly ILogger<ActionFilter> _logger;

        public ActionFilter(ILogger<ActionFilter> logger)
        {
            _logger = logger;
        }

        //Action 執行前執行
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("進入 Action Filter。");
        }

        //Action 執行後執行
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"離開 Action Filter。 \r\n");

        }

    }

}
