using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FRPG.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FRPG.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Players.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            player.User = currentUser;
            _db.Players.Add(player);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(players => players.Id == id);
            return View(thisPlayer);
        }
        [HttpPost]
        public IActionResult Edit(Player player)
        {
            _db.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(players => players.Id == id);
            return View(thisPlayer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(players => players.Id == id);
            _db.Players.Remove(thisPlayer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Deets(int id)
        {
            var thisPlayer = _db.Players.FirstOrDefault(players => players.Id == id);
            return View(thisPlayer);
        }
        public IActionResult Color()
        {
            return View();
        }
    }
}
