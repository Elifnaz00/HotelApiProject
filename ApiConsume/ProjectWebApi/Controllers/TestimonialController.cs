﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _TestimonialService.TGetList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult AddTestimonial(Testimonial Testimonial)
        {
            _TestimonialService.TInsert(Testimonial);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _TestimonialService.GetByID(id);
            _TestimonialService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _TestimonialService.TUpdate(Testimonial);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _TestimonialService.GetByID(id);
            return Ok(values);
        }
    }
}
