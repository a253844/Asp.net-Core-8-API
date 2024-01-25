using Microsoft.AspNetCore.Mvc;
using Pipelines.Sockets.Unofficial.Arenas;

namespace BlockAction.API.Controllers
{

    public class Country
    {
        public string name { get; set; }
    
        public int code { get; set; }

        public int UTC { get; set; }

        public string area { get; set; }
    }

    public class LinqController : Controller
    {

        public IActionResult Index()
        {

            List<Country> countryList = new List<Country>();
            countryList.Add(new Country() { name = "Taiwan", code = 886, UTC = 8 , area = "Asia"});
            countryList.Add(new Country() { name = "Japan", code = 842, UTC = 7, area = "Asia" });
            countryList.Add(new Country() { name = "Korea", code = 820, UTC = 7, area = "Asia" });
            countryList.Add(new Country() { name = "USA", code = 722, UTC = -8, area = "North America" });

            var filterArea =  countryList.Where(p => p.area == "Asia").OrderBy(p => p.code ).Select(p => p.name).ToList();

            var filterArea2 = from p in countryList
                              where p.name == "Asia"
                              orderby p.code ascending
                              select p.name;

            List<int> numbers1 = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
            List<int> numbers2 = [15, 14, 11, 13, 19, 18, 16, 17, 12, 10];

            var concatenationQuery = numbers1.Concat(numbers2);


            return View();
        }

    }

    
}
