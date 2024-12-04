using HotelProject.BusinessLayer.Abstract;
using HotelProject.WebUI.Dtos.ReservationDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{

    [AllowAnonymous]
    public class AdminReservationController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;


        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:38966/api/Reservation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jSonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jSonData);
                return View(values);
            }
            return View();

        }


        public async Task<IActionResult> ApprovedReservation2(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:38966/api/Reservation/Approvad?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
