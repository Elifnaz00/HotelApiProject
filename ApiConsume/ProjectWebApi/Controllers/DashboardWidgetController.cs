using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {

        private readonly IStaffService _staffService;
        private readonly IReservationService _rezervationService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetController(IStaffService staffService, IReservationService rezervationService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _rezervationService = rezervationService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffList()
        {
            var value= _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("RezervationCount")]
        public IActionResult RezervationList()
        {
            var value = _rezervationService.TGetReservationCount();
            return Ok(value);
        }


        [HttpGet("AppUserCount")]
        public IActionResult AppUserList()
        {
            var value = _appUserService.TAppUserCount();
            return Ok(value);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomList()
        {
            var value = _roomService.TRoomCount();
            return Ok(value);
        }

    }
}
