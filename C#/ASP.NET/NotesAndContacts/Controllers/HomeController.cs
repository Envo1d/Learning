using ASP_HW1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW1.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        public IActionResult Index()
        {
            return View();
        }

        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Note()
        {
            return View(Notes.Notices);
        }
        [HttpPost]
        public IActionResult Note(string title, string text, string tags)
        {
            Notes.AddNew(title, text, tags);
            return RedirectToAction("Note");
        }
        public IActionResult Delete(int idx)
        {
            Notes.DeleteElem(idx);
            return RedirectToAction("Note");
        }
        [HttpPost]
        public VirtualFileResult Save(string fileInfo)
        {
            Notes.SaveToFile(fileInfo);
            var filepath = Path.Combine("~/Files", fileInfo);
            return File(filepath, "text/plain", fileInfo);
        }
        [HttpPost]
        public async Task<IActionResult> Load(IFormFile file)
        {
            if (file != null)
            {
                string path = "/Files/" + file.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                Notes.LoadFromFile(file.FileName);
            }
            return RedirectToAction("Note");
        }
        public IActionResult Contact()
        {
            return View(Contacts.ContactsList);
        }
        [HttpPost]
        public IActionResult Contact(string name, int number, int altNumber, string email, string desc)
        {
            Contacts.AddNew(name, number, altNumber, email, desc);
            return Redirect("Contact");
        }
        public IActionResult DeleteContact(int idx)
        {
            Contacts.DeleteElem(idx);
            return RedirectToAction("Contact");
        }
        [HttpPost]
        public VirtualFileResult SaveContacts(string fileInfo)
        {
            Contacts.SaveToFile(fileInfo);
            var filepath = Path.Combine("~/Files", fileInfo);
            return File(filepath, "text/plain", fileInfo);
        }
        [HttpPost]
        public async Task<IActionResult> LoadContacts(IFormFile file)
        {
            if (file != null)
            {
                string path = "/Files/" + file.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                Contacts.LoadFromFile(file.FileName);
            }
            return RedirectToAction("Contact");
        }
    }
}
