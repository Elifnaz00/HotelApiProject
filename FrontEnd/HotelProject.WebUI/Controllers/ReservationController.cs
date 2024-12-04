using HotelProject.WebUI.Dtos.ReservationDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public PartialViewResult _ReservationPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _ReservationPartial(CreateReservationDto createReservationDto)
        {
            createReservationDto.Status = "Onay Bekliyor";

            var client = _httpClientFactory.CreateClient();
            var jSonData= JsonConvert.SerializeObject(createReservationDto);
            StringContent content = new StringContent(jSonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:38966/api/Reservation", content);
            return RedirectToAction("Index", "Default");
        }


    }
}
