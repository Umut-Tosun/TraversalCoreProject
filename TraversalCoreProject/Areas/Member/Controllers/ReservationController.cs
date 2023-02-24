using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        DestinationManager DestinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager ReservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
        public async Task<IActionResult> MyAcceptedReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = ReservationManager.TGetAcceptedReservationById(user.Id).ToList();
            return View(values);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = ReservationManager.TGetReservationById(user.Id).ToList();
            return View(values);
        }
    }
}
