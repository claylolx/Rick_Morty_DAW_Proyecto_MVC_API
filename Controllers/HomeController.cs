using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROJECTE_DAW_API.Models;
using Newtonsoft.Json;

namespace PROJECTE_DAW_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Characters(int page = 1)
        {
            string rickandmortyApiUrl = $"https://rickandmortyapi.com/api/character?page={page}";
            string rickandmortyApiResponse = GetApiResponse(rickandmortyApiUrl);
            var charactersResponse = JsonConvert.DeserializeObject<Characters>(rickandmortyApiResponse);

            ViewBag.NextPage = charactersResponse.info.next != null ? page + 1 : (int?)null;
            ViewBag.PrevPage = charactersResponse.info.prev != null ? page - 1 : (int?)null;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = charactersResponse.info.pages;

            return View(charactersResponse.results);
        }

        static string GetApiResponse(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
