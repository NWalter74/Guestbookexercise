using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämning3.Pages
{
    [Authorize]
    public class ForumModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
