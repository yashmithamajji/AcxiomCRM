using Microsoft.AspNetCore.Mvc;
using AcxiomCRM.Data;

namespace AcxiomCRM.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalCustomers = _context.Customers.Count();
            ViewBag.TotalLeads = 0;
            ViewBag.OpenLeads = 0;
            ViewBag.TotalOpportunities = 0;
            ViewBag.OpenOpportunities = 0;
            ViewBag.WonOpportunities = 0;
            ViewBag.LostOpportunities = 0;
            ViewBag.PipelineValue = 0;

            return View();
        }
    }
}