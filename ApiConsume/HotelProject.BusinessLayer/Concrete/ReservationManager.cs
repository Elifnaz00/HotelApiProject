using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccesLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

       

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public Reservation GetByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public void GetReservationApprovad(int id)
        {
            _reservationDal.GetReservationApprovad(id);
        }

        public List<Reservation> Last6Reservation()
        {
            return _reservationDal.Last6Reservation();
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public int TGetReservationCount()
        {
            return _reservationDal.GetReservationCount();  
        }

        public Reservation TGetReservations(int id)
        {
            return _reservationDal.GetReservations(id);
        }

        public void TInsert(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
