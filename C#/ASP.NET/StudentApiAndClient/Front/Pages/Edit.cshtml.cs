using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Front.Pages
{
    public class EditModel : PageModel
    {
        public string ApiUrl { get; private set; }
        private readonly HttpClient _client;

        public EditModel(IConfiguration conf, HttpClient client)
        {
            ApiUrl = conf["ApiUrl"];
            _client = client;
        }

        public Student Student { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _client.GetAsync(ApiUrl + '/' + HttpContext.Request.Query["id"]);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                Student = JsonSerializer.Deserialize(json, typeof(Student), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) as Student;
            }
        }
        public async Task<IActionResult> OnPostAsync(Guid id, string fullname, string recordbook, string phone, int course)
        {
            var data = new StringContent(JsonSerializer.Serialize(new Student { FullName = fullname, RecordBook = recordbook, Phone = phone, Course = course }), encoding: System.Text.Encoding.UTF8, "application/json");
            var request = await _client.PutAsync($"{Path.Combine(ApiUrl, $"{id}")}", data);
            request.EnsureSuccessStatusCode();
            return RedirectToPage("/Index");
        }
    }
}
