using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PROJECTE_DAW_API.Models;
using PROJECTE_DAW_API.Models.Naruto;

namespace PROJECTE_DAW_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RMCharacters(int page = 1)
        {
            string rickAndMortyApiUrl = $"https://rickandmortyapi.com/api/character?page={page}";
            string rickAndMortyApiResponse = GetApiResponse(rickAndMortyApiUrl);
            var charactersResponse = JsonConvert.DeserializeObject<Characters>(rickAndMortyApiResponse);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = charactersResponse.info.pages;
            ViewBag.NextPage = charactersResponse.info.next != null ? page + 1 : (int?)null;
            ViewBag.PrevPage = charactersResponse.info.prev != null ? page - 1 : (int?)null;

            return View(charactersResponse.results);
        }


        public IActionResult NarutoCharacters(int page = 1)
        {
            string narutoApiUrl = $"https://narutodb.xyz/api/character";
            string narutoApiResponse = GetApiResponse(narutoApiUrl);
            var narutoCharactersResponse = JsonConvert.DeserializeObject<Root>(narutoApiResponse);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)narutoCharactersResponse.totalCharacters / narutoCharactersResponse.pageSize);
            ViewBag.NextPage = page < ViewBag.TotalPages ? page + 1 : (int?)null;
            ViewBag.PrevPage = page > 1 ? page - 1 : (int?)null;

            return View(narutoCharactersResponse);
        }


        private string GetApiResponse(string url)
        {
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
