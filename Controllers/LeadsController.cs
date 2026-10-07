using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcxiomCRM.Data;
using AcxiomCRM.Models;

namespace AcxiomCRM.Controllers
{
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var leads = _context.Leads.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                leads = leads.Where(l =>
                    l.Name.Contains(search) ||
                    l.Email.Contains(search) ||
                    l.Company.Contains(search) ||
                    l.Status.Contains(search));
            }

            return View(await leads.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lead lead)
        {
            if (ModelState.IsValid)
            {
                _context.Leads.Add(lead);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(lead);
        }
    }
}