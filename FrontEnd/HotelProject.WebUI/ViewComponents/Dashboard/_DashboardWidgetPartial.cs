using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpClientFactory _httpClientFactory2;
        private readonly IHttpClientFactory _httpClientFactory3;
        private readonly IHttpClientFactory _httpClientFactory4;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory, IHttpClientFactory httpClientFactory2, IHttpClientFactory httpClientFactory3, IHttpClientFactory httpClientFactory4)
        {
            _httpClientFactory = httpClientFactory;
            _httpClientFactory2 = httpClientFactory2;
            _httpClientFactory3 = httpClientFactory3;
            _httpClientFactory4 = httpClientFactory4;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory2.CreateClient();
            var client3 = _httpClientFactory3.CreateClient();
            var client4 = _httpClientFactory4.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:38966/api/DashboardWidget/StaffCount");
            var responseMessage2 = await client2.GetAsync("http://localhost:38966/api/DashboardWidget/RezervationCount");
            var responseMessage3 = await client2.GetAsync("http://localhost:38966/api/DashboardWidget/AppUserCount");
            var responseMessage4 = await client2.GetAsync("http://localhost:38966/api/DashboardWidget/RoomCount");
           
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var JsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var JsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var JsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                ViewBag.data= JsonData;
                ViewBag.data2= JsonData2;
                ViewBag.data3= JsonData3;
                ViewBag.data4= JsonData4;
                //var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(JsonData);
                
          
            return View();
            
        }


    }
}
