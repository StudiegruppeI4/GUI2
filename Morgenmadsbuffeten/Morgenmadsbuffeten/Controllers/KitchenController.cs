using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data;

namespace Morgenmadsbuffeten.Controllers
{
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["NotCheckedIn"] = await _context.RoomsCheckedIn.Where(b => b.Date == DateTime.Today).ToListAsync();
            return View(await _context.Breakfasts.Where(b => b.Date == DateTime.Today).FirstOrDefaultAsync());
        }
    }
}