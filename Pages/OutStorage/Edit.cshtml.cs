using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using l4.Data;
using l4.Models;

namespace l5.Pages.OutStorage
{
    public class EditModel : PageModel
    {
        private readonly l4.Data.DbConnection _context;

        public EditModel(l4.Data.DbConnection context)
        {
            _context = context;
        }

        [BindProperty]
        public BookOutOfStorage BookOutOfStorage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookOutOfStorages == null)
            {
                return NotFound();
            }

            var bookoutofstorage =  await _context.BookOutOfStorages.FirstOrDefaultAsync(m => m.Id == id);
            if (bookoutofstorage == null)
            {
                return NotFound();
            }
            BookOutOfStorage = bookoutofstorage;
           ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
           ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            BookOutOfStorage.Person = await _context.People.FindAsync(BookOutOfStorage.PersonId);
            BookOutOfStorage.Book = await _context.Books.FindAsync(BookOutOfStorage.BookId);

            _context.Attach(BookOutOfStorage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookOutOfStorageExists(BookOutOfStorage.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookOutOfStorageExists(int id)
        {
          return _context.BookOutOfStorages.Any(e => e.Id == id);
        }
    }
}
