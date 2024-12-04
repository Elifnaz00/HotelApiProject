using HotelProject.DataAccesLayer.Abstract;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.DataAccesLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccesLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        
        public EfReservationDal(Context context) : base(context)
        {
        }

        public Reservation GetReservations(int id)
        {
            var context = new Context();
            return context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault(); 
        }

        public void GetReservationApprovad(int id)
        {
            var context = new Context();
            var values= context.Reservations.Find(id);
            values.Status = "Onaylandı";
            context.SaveChangesAsync();
        }

        public int GetReservationCount()
        {
            var context = new Context();
            return context.Reservations.Count();
        }

        public List<Reservation> Last6Reservation()
        {
            var context = new Context();
            return context.Reservations.OrderByDescending(x => x.ReservationID).Take(6).ToList();   
        }
    }
}
