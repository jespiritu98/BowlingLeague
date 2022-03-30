using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
      
        private BowlersDbContext _Context { get; set; }

       
        //Constructor
        public HomeController(BowlersDbContext temp)
        {
            _Context = temp;
        }

        public IActionResult Index()
        {
            List<Team> teams = _Context.Teams.ToList();

            return View(teams);
        }
        public IActionResult BowlerList()
        {
            List<Bowler> bowlers = _Context.Bowlers.Include(b => b.Team)
           .OrderBy(b => b.TeamID)
           .ToList();
          



            return View(bowlers);
        }

        [HttpGet]
        public IActionResult BowlerForm()
        {
            ViewBag.Teams = _Context.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler response)

        {
            if (ModelState.IsValid)
            {
                _Context.Add(response);
                _Context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                return View(response);
            }
          
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var bowler = _Context.Bowlers.Single(b => b.BowlerID == bowlerid);

            return View("BowlerForm", bowler);
        }

        [HttpPost]

        public IActionResult Edit(Bowler bowler)
        {
            _Context.Update(bowler);
            _Context.SaveChanges();

            return RedirectToAction("BowlerList");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _Context.Bowlers.Single(b => b.BowlerID == bowlerid);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            _Context.Bowlers.Remove(bowler);
            _Context.SaveChanges();

            return RedirectToAction("BowlerList");
        }
    
    }
}
