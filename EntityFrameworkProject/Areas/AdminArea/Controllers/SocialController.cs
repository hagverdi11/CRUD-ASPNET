using EntityFrameworkProject.Data;
using EntityFrameworkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SocialController : Controller
    {
        private readonly AppDbContext _context;
        public SocialController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Social> socials = await _context.Socials.ToListAsync();
            return View(socials);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Social social)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            bool isExist = await _context.Socials.AnyAsync(m => m.Name.Trim() == social.Name.Trim());


            if (isExist)
            {
                ModelState.AddModelError("Name", "Social media name already exist");
                return View();
            }

            await _context.Socials.AddAsync(social);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
