using Microsoft.AspNetCore.Mvc;
using logic.controllers;
using NuGet.Packaging.Licenses;
using System.Collections.Generic;

namespace dartswebsite.Controllers
{

    public class IndexController : Controller
    {
        public PlayerCollection playerCollection = new();
        // GET: IndexController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IndexController/Details/5
        public async Task<models.PlayerViewModel> GetUser(int id)
        {
            models.PlayerViewModel player = new models.PlayerViewModel(await playerCollection.Getplayer(id));
            return player;
        }

        public async Task<List<models.PlayerViewModel>> GetUsers(int id)
        {
            List<models.PlayerViewModel> players = new List<models.PlayerViewModel>();
            List<logic.Models.PlayerModel>playermodels = await playerCollection.GetAllplayers();
            foreach(logic.Models.PlayerModel playermodel in playermodels)
            {
                players.Add(new models.PlayerViewModel(playermodel));
            }

            return players;
        }

        // GET: IndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}