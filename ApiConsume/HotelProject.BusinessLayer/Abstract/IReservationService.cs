using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        public Reservation TGetReservations(int id);
        public void GetReservationApprovad(int id);
        public int TGetReservationCount();

        List<Reservation> Last6Reservation();
    }
}
