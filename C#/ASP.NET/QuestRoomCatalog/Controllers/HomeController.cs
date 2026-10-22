using ASP_HW4.Domain;
using ASP_HW4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository _repository;

        public HomeController(ILogger<HomeController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["diff"] = await _repository.GetDiffNames();
            ViewData["fl"] = await _repository.GetFLNames();
            ViewData["pn"] = await _repository.GetPNumbers();
            return View(await _repository.GetQuestRooms());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string diff, string fl, int pn, string filt)
        {
            ViewData["diff"] = await _repository.GetDiffNames();
            ViewData["fl"] = await _repository.GetFLNames();
            ViewData["pn"] = await _repository.GetPNumbers();
            if (!string.IsNullOrEmpty(diff) && filt=="diff")
                return View(await _repository.GetQuestRoomsByDiff(diff));
            else if (!string.IsNullOrEmpty(fl) && filt == "fl")
                return View(await _repository.GetQuestRoomsByFl(fl));
            else
                return View(await _repository.GetQuestRoomsByPn(pn));
        }

       public IActionResult Details(int id)
        {
            return View(_repository.GetQuestRoomDetails(id).Result.First());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
