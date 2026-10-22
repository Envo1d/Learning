using ASP_HW2.Domain.Abstract;
using ASP_HW2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISaver _saver;

        public HomeController(ILogger<HomeController> logger, ISaver saver)
        {
            _logger = logger;
            _saver = saver;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            Tasker.Counter = 0;
            return View();
        }

        public IActionResult Results()
        {
            Tasker.Counter = 0;
            ViewData["res"] = _saver.Results;
            return View();
        }

        public IActionResult Result()
        {
            byte[] dName;
            if (HttpContext.Session.TryGetValue("name", out dName))
                ViewData["name"] = Encoding.UTF8.GetString(dName);
            List<List<string>> tasks = new();
            byte[] tmp;
            byte[] tmp2;
            byte[] tmp3;
            for (int i = 1; i <= Tasker.Counter; i++)
            {
                if (HttpContext.Session.TryGetValue($"Answer{i}", out tmp))
                {
                    if (HttpContext.Session.TryGetValue($"Correct{i}", out tmp2))
                    {
                        if(HttpContext.Session.TryGetValue($"Question{i}", out tmp3))
                        tasks.Add(new List<string> { Encoding.UTF8.GetString(tmp3), Encoding.UTF8.GetString(tmp), Encoding.UTF8.GetString(tmp2) });
                    }
                } 
            }
            ViewData["tasks"] = tasks;
            ViewData["mark"] = _saver.Results[Encoding.UTF8.GetString(dName)];
            HttpContext.Session.Clear();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Test(int answer, string name, bool skip = false, bool save = false)
        {
            if((!skip && !save) && HttpContext.Session.Keys.Contains("name"))
            {
                byte[] dName;
                if (HttpContext.Session.TryGetValue("name", out dName))
                    ViewData["name"] = Encoding.UTF8.GetString(dName);
                ViewData["Task"] = Tasker.CurrentQuestion;
            }
            else
            {
                if (!string.IsNullOrEmpty(name) && !HttpContext.Session.Keys.Contains("name"))
                {
                    HttpContext.Session.Set("name", Encoding.UTF8.GetBytes(name));
                    if (!_saver.Results.ContainsKey(name))
                        _saver.Results.Add(name, 0);
                    else
                        _saver.Results[name] = 0;
                    ViewData["name"] = name;
                    ViewData["Task"] = Tasker.GetTask();
                }
                else
                {
                    byte[] dName;
                    if (HttpContext.Session.TryGetValue("name", out dName))
                        ViewData["name"] = Encoding.UTF8.GetString(dName);
                    if (skip)
                    {
                        HttpContext.Session.Set($"Question{Tasker.Counter}", Encoding.UTF8.GetBytes(Tasker.CurrentQuestion));
                        HttpContext.Session.Set($"Answer{Tasker.Counter}", Encoding.UTF8.GetBytes("Skiped"));
                        HttpContext.Session.Set($"Correct{Tasker.Counter}", Encoding.UTF8.GetBytes($"{Tasker.CorrectAnswer}"));
                    }
                    else if (save)
                    {
                        HttpContext.Session.Set($"Question{Tasker.Counter}", Encoding.UTF8.GetBytes(Tasker.CurrentQuestion));
                        HttpContext.Session.Set($"Answer{Tasker.Counter}", Encoding.UTF8.GetBytes($"{answer}"));
                        HttpContext.Session.Set($"Correct{Tasker.Counter}", Encoding.UTF8.GetBytes($"{Tasker.CorrectAnswer}"));
                        if (answer == Tasker.CorrectAnswer)
                            _saver.Results[Encoding.UTF8.GetString(dName)]++;
                    }
                    if (Tasker.Counter < 10)
                        ViewData["Task"] = Tasker.GetTask();
                    else
                        return RedirectToAction("Result");
                }
            }
            ViewData["timer"] = Tasker.Timer.ToString(Tasker.TimerFormat);
            return View();
        }
    }
}
