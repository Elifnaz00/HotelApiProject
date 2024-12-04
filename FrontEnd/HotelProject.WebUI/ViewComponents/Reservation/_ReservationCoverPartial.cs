using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Reservation
{
    public class _ReservationCoverPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
