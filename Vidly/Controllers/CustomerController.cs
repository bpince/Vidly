using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var selectedCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (selectedCustomer != null)
            {
                return View(selectedCustomer);
            }
            else
            {
                return HttpNotFound();
            }
            
        }
    }
}