using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccesLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        public Reservation GetReservations(int id); 

        public void GetReservationApprovad(int id);

        int GetReservationCount();

        List<Reservation> Last6Reservation();


    }
}
