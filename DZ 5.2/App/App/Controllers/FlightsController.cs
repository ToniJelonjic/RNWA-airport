using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App;
using App.Models;

namespace App.Controllers
{
    public class FlightsController : Controller
    {
        private readonly airportdbContext _context;

        public FlightsController(airportdbContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var airportdbContext = _context.Flights.Include(f => f.Airline).Include(f => f.Airplane).Include(f => f.FlightnoNavigation).Include(f => f.FromNavigation).Include(f => f.ToNavigation);
            return View(await airportdbContext.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Airline)
                .Include(f => f.Airplane)
                .Include(f => f.FlightnoNavigation)
                .Include(f => f.FromNavigation)
                .Include(f => f.ToNavigation)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "Iata");
            ViewData["AirplaneId"] = new SelectList(_context.Airplanes, "AirplaneId", "AirplaneId");
            ViewData["Flightno"] = new SelectList(_context.Flightschedules, "Flightno", "Flightno");
            ViewData["From"] = new SelectList(_context.Airports, "AirportId", "Icao");
            ViewData["To"] = new SelectList(_context.Airports, "AirportId", "Icao");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,Flightno,From,To,Departure,Arrival,AirlineId,AirplaneId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "Iata", flight.AirlineId);
            ViewData["AirplaneId"] = new SelectList(_context.Airplanes, "AirplaneId", "AirplaneId", flight.AirplaneId);
            ViewData["Flightno"] = new SelectList(_context.Flightschedules, "Flightno", "Flightno", flight.Flightno);
            ViewData["From"] = new SelectList(_context.Airports, "AirportId", "Icao", flight.From);
            ViewData["To"] = new SelectList(_context.Airports, "AirportId", "Icao", flight.To);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "Iata", flight.AirlineId);
            ViewData["AirplaneId"] = new SelectList(_context.Airplanes, "AirplaneId", "AirplaneId", flight.AirplaneId);
            ViewData["Flightno"] = new SelectList(_context.Flightschedules, "Flightno", "Flightno", flight.Flightno);
            ViewData["From"] = new SelectList(_context.Airports, "AirportId", "Icao", flight.From);
            ViewData["To"] = new SelectList(_context.Airports, "AirportId", "Icao", flight.To);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,Flightno,From,To,Departure,Arrival,AirlineId,AirplaneId")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineId"] = new SelectList(_context.Airlines, "AirlineId", "Iata", flight.AirlineId);
            ViewData["AirplaneId"] = new SelectList(_context.Airplanes, "AirplaneId", "AirplaneId", flight.AirplaneId);
            ViewData["Flightno"] = new SelectList(_context.Flightschedules, "Flightno", "Flightno", flight.Flightno);
            ViewData["From"] = new SelectList(_context.Airports, "AirportId", "Icao", flight.From);
            ViewData["To"] = new SelectList(_context.Airports, "AirportId", "Icao", flight.To);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Airline)
                .Include(f => f.Airplane)
                .Include(f => f.FlightnoNavigation)
                .Include(f => f.FromNavigation)
                .Include(f => f.ToNavigation)
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }
    }
}
