using ASP_HW3.Domain.Abstracts;
using ASP_HW3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW3.Controllers
{
    public class FibonacciController : Controller
    {
        private readonly ICacher cacher;
        public FibonacciController(ICacher cacher) => this.cacher = cacher;
        public IActionResult Index(int? num)
        {
            if (num.HasValue)
            {
                ViewData["Task"] = num;
                ViewData["Res"] = cacher.Results[num];
            }
            else
            {
                Microsoft.AspNetCore.Http.PathString numn;
                HttpContext.Request.Path.StartsWithSegments(new Microsoft.AspNetCore.Http.PathString("/fibonacci/Index"), out numn);
                string res = numn.ToString();
                res = res.Remove(0, 1);
                ViewData["Task"] = res;
                ViewData["Res"] = cacher.Results[Convert.ToInt32(res)];
            }
            return View();
        }
    }
}
