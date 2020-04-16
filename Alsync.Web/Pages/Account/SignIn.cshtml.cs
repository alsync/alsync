using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alsync.Web.Pages.Account
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public bool RemeberMe { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                return Redirect("/index");
            }
            return Page();
        }
    }
}