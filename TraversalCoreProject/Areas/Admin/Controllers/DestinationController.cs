using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var destinations = destinationManager.TGetList();
            return View(destinations);
        }
        [HttpGet]
        public IActionResult AddDestination() => View();
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.status = false;
            destinationManager.TAdd(destination);
            return RedirectToAction("Destination", "Admin", "Index");
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            Destination destination=destinationManager.TGetById(id);
            return View(destination);

        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            var model = destinationManager.TGetById(destination.DestinationId);
            model.City=destination.City;
            model.DayNight=destination.DayNight;
            model.price = destination.price;
            model.Capacity=destination.Capacity;
            model.CoverImageUrl=destination.CoverImageUrl;
            model.ImageUrl=destination.ImageUrl;
            model.Description=destination.Description;
            destinationManager.TUpdate(model);
            return RedirectToAction("Destination","Admin","Index");
        }
        public IActionResult DeleteDestination(int id)
        {
            Destination destination = destinationManager.TGetById(id);
            destinationManager.TDelete(destination);
            return RedirectToAction("Destination", "Admin", "Index");
        }
    }
}
