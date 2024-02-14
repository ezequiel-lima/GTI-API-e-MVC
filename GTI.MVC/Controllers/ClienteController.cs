﻿using AutoMapper;
using GTI.MVC.Dtos;
using GTI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace GTI.MVC.Controllers
{
    public class ClienteController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7052/");
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ClienteViewModel> listaClientes = new List<ClienteViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result = JsonSerializer.Deserialize<ResultViewModel<List<ClienteViewModel>>>(data, options);
                listaClientes = result?.Data;
            }

            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            var clienteParaEnviar = _mapper.Map<ClienteDto>(cliente);

            var jsonCliente = JsonSerializer.Serialize(clienteParaEnviar);
            var content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(baseAddress + "Cliente", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            AddNotificationsError(response);

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"Cliente/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                JsonSerializerOptions options = ConfigureJsonSerializer();

                var result = JsonSerializer.Deserialize<ResultViewModel<List<ClienteViewModel>>>(data, options);
                cliente = result.Data[0];
            }

            return View(cliente);
        }

        public async Task<IActionResult> Edit(Guid id, ClienteViewModel cliente)
        {
            var clienteParaEnviar = _mapper.Map<ClienteDto>(cliente);

            var jsonCliente = JsonSerializer.Serialize(clienteParaEnviar);

            var content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(baseAddress + $"Cliente/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            AddNotificationsError(response);

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"Cliente/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                JsonSerializerOptions options = ConfigureJsonSerializer();

                var result = JsonSerializer.Deserialize<ResultViewModel<List<ClienteViewModel>>>(data, options);
                cliente = result.Data[0];
            }

            return View(cliente);
        }

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(baseAddress + $"Cliente/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + $"Cliente/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                JsonSerializerOptions options = ConfigureJsonSerializer();

                var result = JsonSerializer.Deserialize<ResultViewModel<List<ClienteViewModel>>>(data, options);
                cliente = result.Data[0];
            }

            return View(cliente);
        }

        private static JsonSerializerOptions ConfigureJsonSerializer()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        private void AddNotificationsError(HttpResponseMessage response)
        {
            string data = response.Content.ReadAsStringAsync().Result;
            JsonSerializerOptions options = ConfigureJsonSerializer();
            var result = JsonSerializer.Deserialize<ResultViewModel<List<NotificationsViewModel>>>(data, options);

            foreach (var notification in result.Data)
            {
                ModelState.AddModelError(notification.Key, notification.Message);
            }
        }
    }
}
