using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_HW5.Domain;
using ASP_HW5.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ASP_HW5.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ASP_HW5.Domain.AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AdminModel(ASP_HW5.Domain.AppDbContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public PaginatedList<Image> Image { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString, int? pageIndex, string currentFilter)
        {
            if (searchString != null)
                pageIndex = 1;
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Image> images;
            if (!String.IsNullOrEmpty(searchString))
            {
                images = _context.Images.OrderByDescending(x => x.Id).AsNoTracking().Select(im => im).Include(i => i.File).Include(x => x.Tags).
                    Where(x => x.Tags.Any(x => x.Title == searchString));
            }
            else
            {
                images = _context.Images.OrderByDescending(x => x.Id).AsNoTracking().Select(n => n).Include(i => i.File).Include(x => x.Tags);
            }
            var pageSize = _configuration.GetValue("PageSize", 4) * 2;
            Image = await PaginatedList<Image>.CreateAsync(
                images.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
