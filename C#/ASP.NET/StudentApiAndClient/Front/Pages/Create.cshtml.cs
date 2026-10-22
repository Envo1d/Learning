using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Front.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration config;
        public string ApiUrl { get; private set; }
        public CreateModel(IConfiguration conf)
        {
            config = conf;
            ApiUrl = config["ApiUrl"];
        }
        public void OnGet()
        {
        }
    }
}
