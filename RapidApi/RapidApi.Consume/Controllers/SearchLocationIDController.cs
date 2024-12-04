using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityname)
        {
            if (string.IsNullOrEmpty(cityname))
            {
                List<BookingApiLocationSearchViewModel> bookingApiLocationSearchViewModel = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "dfa145565dmsh63d9f20ca4ebab1p1e0a81jsndea2436ae272" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingApiLocationSearchViewModel = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(bookingApiLocationSearchViewModel.Take(1).ToList());
                   

                }


            }
            else
            {
                List<BookingApiLocationSearchViewModel> bookingApiLocationSearchViewModel = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "dfa145565dmsh63d9f20ca4ebab1p1e0a81jsndea2436ae272" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingApiLocationSearchViewModel = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(bookingApiLocationSearchViewModel.Take(1).ToList());

                }
               
              
                   

                }

            }
        }
    }


