using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vote.Pages
{
    public class IndexModel : PageModel
    {
        public string HostName { get; set; } = Environment.MachineName;
        public string OptionA { get; set; } = "Tabs";
        public string OptionB { get; set; } = "Spaces";


        [BindProperty]
        public string Vote { get; set; }

        public async Task OnGetAsync()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }

    }
}
