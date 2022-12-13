﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using l4.Data;
using l4.Models;

namespace l5.Pages.OutStorage
{
    public class DeleteModel : PageModel
    {
        private readonly l4.Data.DbConnection _context;

        public DeleteModel(l4.Data.DbConnection context)
        {
            _context = context;
        }

        [BindProperty]
      public BookOutOfStorage BookOutOfStorage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookOutOfStorages == null)
            {
                return NotFound();
            }

            var bookoutofstorage = await _context.BookOutOfStorages.FirstOrDefaultAsync(m => m.Id == id);

            if (bookoutofstorage == null)
            {
                return NotFound();
            }
            else 
            {
                BookOutOfStorage = bookoutofstorage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookOutOfStorages == null)
            {
                return NotFound();
            }
            var bookoutofstorage = await _context.BookOutOfStorages.FindAsync(id);

            if (bookoutofstorage != null)
            {
                BookOutOfStorage = bookoutofstorage;
                _context.BookOutOfStorages.Remove(BookOutOfStorage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
