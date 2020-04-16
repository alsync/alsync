using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alsync.Web.Pages
{
    public class FollowModel : PageModel
    {
        public string Name { get; set; }

        public void OnGet()
        {
            this.Name = "test";
        }

        public void OnPost()
        {
        }

        public IActionResult OnPostTest()
        {
            this.Name = "hehe";
            return Page();
        }
    }
}