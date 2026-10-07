using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcxiomCRM.Data;
using AcxiomCRM.Models;

namespace AcxiomCRM.Controllers
{
    [Authorize]
    public class FollowUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.FollowUps.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FollowUp followUp)
        {
            if (followUp.FollowUpDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "FollowUpDate",
                    "Follow-up date cannot be in the past.");
            }

            if (ModelState.IsValid)
            {
                _context.FollowUps.Add(followUp);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(followUp);
        }
    }
}