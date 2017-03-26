using System.Web.Mvc;

namespace ValueVideo.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult RentalForm()
        {
            return View();
        }

        public ActionResult OutStandingRentals()
        {
            return View();
        }

        public ActionResult AllRentals()
        {
            return View();
        }
    }
}