using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;
using vote.Common;

namespace vote.Pages
{
    public class IndexModel : BasePageModel
    {

        [BindProperty]
        public string Vote { get; set; }

        public async Task OnGetAsync()
        {

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Vote))
            {
                IDatabase db = Redis.GetDatabase();
                var valueInCache = db.StringIncrement(Vote);
            }

            return Page();
        }

    }
}
