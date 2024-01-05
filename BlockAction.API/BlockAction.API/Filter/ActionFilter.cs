using BlockAction.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace BlockAction.API.Filter
{
    public class ActionFilter : IActionFilter
    {
        private readonly ILogger<ActionFilter> _logger;
        private string ActionArguments { get; set; }

        public ActionFilter(ILogger<ActionFilter> logger)
        {
            _logger = logger;
        }

        //Action 執行前執行
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;

            if (context.ActionArguments != null && context.ActionArguments.Count > 0)
            {
                ActionArguments = JsonSerializer.Serialize(context.ActionArguments);
            }
            else
            {
                ActionArguments = string.Empty;
            }

            _logger.LogInformation($"Action Filter Start。 \r\n");
            _logger.LogInformation($"controllerName = {descriptor.ControllerName} ,actionName  = {descriptor.ActionName} ,requestArguments  = {ActionArguments}  \r\n");
        }

        //Action 執行後執行
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action Filter End。 \r\n");

        }

    }

}
