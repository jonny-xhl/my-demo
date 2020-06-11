using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Jonny.AdllDemo.Mvc.ViewComponents.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty]
        public Privacy PrivacyM { get; set; }
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? id)
        {
            PrivacyM = PrivacyStore.GetPrivacies().FirstOrDefault(p => p.Id == id);
        }

        public void OnPostAsync()
        {
            HttpContext.Response.WriteAsync($"{PrivacyM.Id},{PrivacyM.Name}");
        }

        public class Privacy
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class PrivacyStore
        {
            public static IEnumerable<Privacy> GetPrivacies()
            {
                return new List<Privacy>
                {
                    new Privacy{Id=1,Name="first"},
                    new Privacy{Id=2,Name="second"},
                    new Privacy{Id=3,Name="third"},
                    new Privacy{Id=4,Name="fourth"}
                };
            }
        }
    }


}
