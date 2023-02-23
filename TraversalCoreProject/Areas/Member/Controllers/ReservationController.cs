using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        DestinationManager DestinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager ReservationManager = new ReservationManager(new EfReservationDal());
       
        [HttpGet]
        public IActionResult NewReservation()
        {
            ViewBag.DestinationId = new SelectList(DestinationManager.TGetList(), "DestinationId", "City");
            
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
			reservation.Status = false;
            reservation.AppUserId = 3;
            ReservationManager.TAdd(reservation);
            return View("MyCurrentReservation");
        }
        public IActionResult MyCurrentReservation()
        {
            return View();
        }
    }
}
