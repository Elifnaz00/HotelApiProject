using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ReservationDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly Context _context;

        public ReservationController(IReservationService reservationService, Context context)
        {
            _reservationService = reservationService;
            _context = context;
        }

        

        [HttpGet]
        public IActionResult GetReservation()
        { 
            var result= _reservationService.TGetList();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            _reservationService.TInsert(reservation);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateReservation()
        {
            return Ok();
        }

        
        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var values= _reservationService.GetByID(id);
            _reservationService.TUpdate(values);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdReservation()
        {
            return Ok();
        }


        [HttpGet("Approvad")]
        public IActionResult ApprovadReservation(int id) //id'ye göre güncelleme
        {
            _reservationService.GetReservationApprovad(id);
           return Ok();
            

            
        }
    }
}
