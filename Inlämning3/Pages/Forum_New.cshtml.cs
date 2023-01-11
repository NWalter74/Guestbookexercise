using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämning3.Pages
{
    public class Forum_NewModel : PageModel
    {
        public object signInManager { get; private set; }

        public void OnGet()
        {
        }
    }
}
