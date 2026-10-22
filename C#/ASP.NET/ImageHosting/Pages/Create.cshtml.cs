using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_HW5.Domain;
using ASP_HW5.Domain.Entities;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ASP_HW5.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ASP_HW5.Domain.AppDbContext _context;
        public IList<Tag> Tags { get; set; }
        public CreateModel(ASP_HW5.Domain.AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Tags = await _context.Tags.Select(x=>x).ToListAsync();
        }

        [BindProperty]
        public Image Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile upload, string []tags)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.Length > 0)
                    {
                        var avatar = new Domain.Entities.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            ContentType = upload.ContentType
                        };
                        using (var dataStream = new MemoryStream())
                        {
                            await upload.CopyToAsync(dataStream);
                            avatar.Content = dataStream.ToArray();
                        }
                        Image.File = avatar;
                    }
                    Image.Tags = new List<Tag>();
                    foreach (var item in tags)
                    {
                        int id;
                        if (Int32.TryParse(item, out id))
                        {
                            if (_context.Tags.Any(t => t.Id == id))
                                Image.Tags.Add(await _context.Tags.FirstOrDefaultAsync(x => x.Id == id));
                        }
                        else
                        {
                            var tag = new Tag { Title = item };
                            await _context.Tags.AddAsync(tag);
                            Image.Tags.Add(tag);
                        }
                    }
                    _context.Images.Add(Image);
                    await _context.SaveChangesAsync();
                    return Redirect("/Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return Redirect("./Index");
        }
    }
}
