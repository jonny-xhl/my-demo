using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jonny.AdllDemo.Mvc.ViewComponents.Pages.Shared.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Jonny.AdllDemo.Mvc.ViewComponents.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //return ViewComponent(typeof(PriorityListViewComponent));
        }
    }
}
