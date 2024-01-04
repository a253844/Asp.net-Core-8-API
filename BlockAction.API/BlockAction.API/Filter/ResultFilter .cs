using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlockAction.API.Filter
{
    public class ResultFilter : IResultFilter
    {

        private readonly ILogger<ResultFilter> _logger;

        public ResultFilter(ILogger<ResultFilter> logger)
        {
            _logger = logger;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //Result 執行前執行
            _logger.LogInformation("進入 Result Filter。");

        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //Result 執行後執行
            _logger.LogInformation("離開 Result Filter。");

        }
    }
}
