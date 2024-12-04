using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
