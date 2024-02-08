using GTI.MVC.Models;
using GTI.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace GTI.MVC.Controllers
{
    public class ClienteController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7052/");
        private readonly HttpClient _httpClient;

        public ClienteController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result = JsonSerializer.Deserialize<ResultViewModel<List<Cliente>>>(data, options);
                listaClientes = result?.Data;
            }

            return View(listaClientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            var jsonCliente = JsonSerializer.Serialize(cliente);

            var content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(baseAddress + "Cliente", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(cliente);
        }
    }
}
