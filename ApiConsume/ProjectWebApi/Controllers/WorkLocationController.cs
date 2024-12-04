using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult GetWorkLocation() 
        {
            var values= _workLocationService.TGetList();
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation workLocation) 
        {
            _workLocationService.TInsert(workLocation);
            return Ok();
        }
        

        [HttpPut]
        public IActionResult EditWorkLocation(WorkLocation workLocation) 
        {
            _workLocationService.TUpdate(workLocation);
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(WorkLocation workLocation) 
        {
            _workLocationService.TDelete(workLocation);
            return Ok();
        }


    }
}
