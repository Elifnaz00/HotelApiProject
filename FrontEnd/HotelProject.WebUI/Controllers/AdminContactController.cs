using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.SendMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class AdminContactController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client= _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var client3 = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.GetAsync("http://localhost:38966/api/Contact");
            var responseMessage2 = await client2.GetAsync("http://localhost:38966/api/Contact/GetContactCount");
            var responseMessage3 = await client3.GetAsync("http://localhost:38966/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jSonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jSonData);
                
                var jSonData2= await responseMessage2.Content.ReadAsStringAsync();
                var jSonData3= await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.contactCount = jSonData2;
                ViewBag.sendMessageCount = jSonData3;
                
                return View(values);
            }

            return View();

        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:38966/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jSonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jSonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            if (ModelState.IsValid)
            {
                createSendMessageDto.SenderMail = "admin@gmail.com";
                createSendMessageDto.SenderName = "Admin";
                createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:38966/api/SendMessage", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SendBox");
                }
                return View();
            }
            else
            {
                return View();
            }
        }

        
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:38966/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jSonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jSonData);
                return View(values);
            }
            return View();
            
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:38966/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jSonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jSonData);
                return View(values);
            }
            return View();

        }


        public PartialViewResult SideBarAdminContactPartial()
        {
           
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
    }
}
