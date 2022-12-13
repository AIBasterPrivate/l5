using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using l4.Data;
using l4.Models;

namespace l5.Pages.OutStorage
{
    public class CreateModel : PageModel
    {
        private readonly l4.Data.DbConnection _context;

        public CreateModel(l4.Data.DbConnection context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Name");
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Firstname");
            return Page();
        }

        [BindProperty]
        public BookOutOfStorage BookOutOfStorage { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            BookOutOfStorage.Person =  await _context.People.FindAsync(BookOutOfStorage.PersonId);
            BookOutOfStorage.Book =  await _context.Books.FindAsync(BookOutOfStorage.BookId);

            _context.BookOutOfStorages.Add(BookOutOfStorage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
