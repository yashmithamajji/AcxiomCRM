using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcxiomCRM.Data;
using AcxiomCRM.Models;

namespace AcxiomCRM.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var opportunities = _context.Opportunities.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                opportunities = opportunities.Where(o =>
                    o.Name.Contains(search) ||
                    o.Customer.Contains(search) ||
                    o.Stage.Contains(search) ||
                    o.Status.Contains(search));
            }

            return View(await opportunities.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Opportunity opportunity)
        {
            if (opportunity.Status == "Open" &&
                opportunity.ExpectedCloseDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "ExpectedCloseDate",
                    "Expected close date cannot be in the past.");
            }

            if (ModelState.IsValid)
            {
                _context.Opportunities.Add(opportunity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(opportunity);
        }
    }
}