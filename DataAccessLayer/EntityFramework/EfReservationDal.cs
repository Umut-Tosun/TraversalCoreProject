using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationOnByAccepted(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations.Include(x => x.Destination).Where(x => x.Status == true && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationOnByWaitApproval(int id)
        {
            using(var c = new Context())
            {
                return c.Reservations.Include(x=>x.Destination).Where(x=>x.Status==false&&x.AppUserId==id).ToList();
            }
        }
    }
}
