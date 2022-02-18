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
    public class TicketController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TicketController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var TikList = await _context.TicketModel.ToListAsync();
            return View(TikList);
        }
        public IActionResult Create()
        {
            List<AirlineModel> tempList = new();
            tempList = (from item in _context.AirlineModel
                           select item).ToList();

            List<AirlineModel> airlineList = new();


            foreach (var item in tempList)
            {
                if (item.available == true)
                {
                    airlineList.Add(item);
                }
            }
            tempList = null;

            List<DestinationModel> cityList = new List<DestinationModel>();
            cityList = (from item in _context.DestinationModel
                        select item).ToList();

            ViewBag.ListofAirlines = airlineList;
            ViewBag.ListofCities = cityList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketModel ticket)
        {

            if (ModelState.IsValid)
            {
                _context.TicketModel.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(ticket);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var ticket = await _context.TicketModel.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            List<AirlineModel> tempList = new();
            tempList = (from item in _context.AirlineModel
                        select item).ToList();

            List<AirlineModel> airlineList = new();


            foreach (var item in tempList)
            {
                if (item.available == true)
                {
                    airlineList.Add(item);
                }
            }
            tempList = null;

            List<DestinationModel> cityList = new List<DestinationModel>();
            cityList = (from item in _context.DestinationModel
                        select item).ToList();

            ViewBag.ListofAirlines = airlineList;
            ViewBag.ListofCities = cityList;
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                _context.TicketModel.Update(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(ticket);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var ticket = await _context.TicketModel.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.TicketModel.FindAsync(id);
            if (ModelState.IsValid)
            {
                _context.TicketModel.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }
    }
}
