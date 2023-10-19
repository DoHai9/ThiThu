using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Json;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient _httpClient ;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            List<SinhVien> sv = await _httpClient.GetFromJsonAsync<List<SinhVien>>("https://localhost:7160/api/SinhVien/Get-SinhVien");

            return View(sv);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Create(SinhVien sv)
        {
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                return View();
            }
            var sv1 = await _httpClient.PostAsJsonAsync<SinhVien>($"https://localhost:7160/api/SinhVien/Add-SinhVien",sv);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        [Route("[action]/{id}")]

        public async Task<IActionResult> Edit(Guid id, SinhVien sv)
        {
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                return View();
            }
            var sv1 = await _httpClient.PutAsJsonAsync<SinhVien>($"https://localhost:7160/api/SinhVien/{id}",sv) ;

            return RedirectToAction("Index");
        }
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sv = await _httpClient.DeleteAsync($"https://localhost:7160/api/SinhVien/{id}");

            return RedirectToAction("Index");
        }
    }
}