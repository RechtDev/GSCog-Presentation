using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCRecap.Data;
using MVCRecap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Controllers
{
    [Authorize]
    public class AirlineController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AirlineController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var airline = await _context.Airline.ToListAsync();
            return View(airline);
        }

    }
}
