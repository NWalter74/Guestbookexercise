using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämning3.Pages.PostList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Posts Book { get; set; }

        public async Task OnGetAsync(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TrådFromDb = await _db.Book.FindAsync(Book.Id);
                TrådFromDb.Namn = Book.Namn;
                TrådFromDb.Rubrik = Book.Rubrik;
                TrådFromDb.Inlägg = Book.Inlägg;

                await _db.SaveChangesAsync();

                return RedirectToPage("PostIndex");
            }

            return RedirectToPage();
        }
    }
}
