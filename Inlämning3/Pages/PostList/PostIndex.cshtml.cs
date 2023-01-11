using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Inlämning3.Pages.PostList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel (ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Posts> Books { get; set; }
        public async Task OnGetAsync()
        {
            //go to database and take all the books to save them inside the IEnumerable
            Books = await _db.Book.ToListAsync();
        }

        //Delete in the name OnPostDelete comes from the asp-page-handler="Delete" from the button on the PostIndex.cshtml page
        public async Task<IActionResult> OnPostDelete (int id)
        {
            var tråd = await _db.Book.FindAsync(id);
            if(tråd == null)
            {
                return NotFound();
            }
            _db.Book.Remove(tråd);
            await _db.SaveChangesAsync();

            return RedirectToPage("PostIndex");
        }
    }
}
