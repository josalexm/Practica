using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practica.Web.Dto;
using Practica.Web.Models;
using System.Diagnostics;

namespace Practica.Web.Controllers
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

        public async Task<IActionResult> Privacy()
        {
            List<ItemDto> items = new List<ItemDto>();
            using (HttpClient client = new HttpClient())
            {
                string url = "https://jsonplaceholder.typicode.com/todos";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode == false)
                    throw new Exception($"Ocurrio un error { response.StatusCode }");

                string jsonReponse = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<ItemDto>>(jsonReponse);
            }

            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}