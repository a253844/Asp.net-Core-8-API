using Microsoft.AspNetCore.Mvc;

namespace BlockAction.API.Controllers
{
    public class ThreadController : Controller
    {
        public IActionResult Index()
        {
            Task.Run(() =>
            {
                Parallel.Invoke(() =>
                {

                });
            });

            return View();
        }
    }
}
