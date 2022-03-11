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
        }AirlineModel

        public async Task<IActionResult> Index()
        {
            var TikList = await _context.Ticket.ToListAsync();
            return View(TikList);
        }
        public IActionResult Create()
        {
            List<Airline> tempList = new();
            tempList = (from item in _context.Airline
                           select item).ToList();

            List<Airline> airlineList = new();

            foreach (var item in tempList)
            {
                if (item.available == true)
                {
                    airlineList.Add(item);
                }
            }
            tempList = null;

            

            List<Destination> cityList = new List<Destination>();
            cityList = (from item in _context.Destination
                        select item).ToList();

            ViewBag.ListofAirlines = airlineList;
            ViewBag.ListofCities = cityList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if(ticket.ReturnDate.Date.CompareTo(ticket.DepartDate.Date) <0)
            {
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                _context.Ticket.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            List<Airline> tempList = new();
            tempList = (from item in _context.Airline
                        select item).ToList();

            List<Airline> airlineList = new();


            foreach (var item in tempList)
            {
                if (item.available == true)
                {
                    airlineList.Add(item);
                }
            }
            tempList = null;

            List<Destination> cityList = new List<Destination>();
            cityList = (from item in _context.Destination
                        select item).ToList();

            ViewBag.ListofAirlines = airlineList;
            ViewBag.ListofCities = cityList;
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket ticket)
        {
            if (ticket.ReturnDate.Date.CompareTo(ticket.DepartDate.Date) < 0)
            {
                return RedirectToAction("Edit");
            }
            if (ModelState.IsValid)
            {
                _context.Ticket.Update(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Edit");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
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
            var ticket = await _context.Ticket.FindAsync(id);
            if (ModelState.IsValid)
            {
                _context.Ticket.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }
    }
}
