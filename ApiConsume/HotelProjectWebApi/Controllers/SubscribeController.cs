﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeGet()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
            
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe) 
        {
            _subscribeService.TInsert(subscribe);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdSubscribe(int id) 
        {
            var values= _subscribeService.GetByID(id);
            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id) 
        {
            var value= _subscribeService.GetByID(id);
            _subscribeService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe) 
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }
    }
}
