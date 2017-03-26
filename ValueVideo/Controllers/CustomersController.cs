using System.Linq;
using System.Web.Mvc;
using ValueVideo.Models;
using ValueVideo.ViewModels;

namespace ValueVideo.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(int? id)
        {
            

            var model = new CustomerFormViewModel()
            {

                MembershipTypes = _context.MembershipTypes.ToList()
            };
            if (id != null)
                model.Customer = _context.Customers.Single(c => c.Id == id);
            return View("CustomerForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            ModelState["customer.Id"].Errors.Clear();

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            else if (customer.Id == 0)
            {
                _context.Customers.Add(customer);         
            }
            else
            {
                var customerFromDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerFromDb.Birthdate = customer.Birthdate;
                customerFromDb.MembershipTypeId = customer.MembershipTypeId;
                customerFromDb.Name = customer.Name;
            }
                _context.SaveChanges();
                return RedirectToAction("Index");

                
        }
    }
}