using Microsoft.AspNetCore.Mvc;

namespace BlockAction.API.Controllers
{
    public class DelegateController : Controller
    {
        public IActionResult Index()
        {
            List<Country> countryList = new List<Country>();
            countryList.Add(new Country() { name = "Taiwan", code = 886, UTC = 8, area = "Asia" });
            countryList.Add(new Country() { name = "Japan", code = 842, UTC = 7, area = "Asia" });
            countryList.Add(new Country() { name = "Korea", code = 820, UTC = 7, area = "Asia" });
            countryList.Add(new Country() { name = "USA", code = 722, UTC = -8, area = "North America" });

            Action<List<Country>> action = i => { i.ForEach(i => Console.WriteLine(i.name)); };
            ShowCountry(countryList, action);

            Func<Country, string, bool> func = (i, j) => i.name == j;
            var result = FindCountry<Country>(countryList, "Taiwan", func);

            return View();
        }

        /// <summary>
        /// 泛型方法 Action 沒有回傳值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList"></param>
        /// <param name="action"></param>
        public static void ShowCountry<T>(List<T> objList, Action<List<T>> action)
        {
            action(objList);
        }


        /// <summary>
        /// 泛型方法 Func 有回傳值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T FindCountry<T>(List<T> objList, string name, Func<T, string, bool> func)
        {
            T item = default(T);
            foreach (var Obj in objList)
            {
                if (func.Invoke(Obj, name))
                {
                    item = Obj;
                }
            }

            return item;
        }

    }
}
