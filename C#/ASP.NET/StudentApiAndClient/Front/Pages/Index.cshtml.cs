using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Front.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;


        public string ApiUrl { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration conf, HttpClient client)
        {
            _logger = logger;
            ApiUrl = conf["ApiUrl"];
            _httpClient = client;
        }

        public async Task<IActionResult> OnGetDelete([FromQuery] Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
            return RedirectToPage();
        }
    }
}
