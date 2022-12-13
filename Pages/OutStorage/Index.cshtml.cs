using System;
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
    public class IndexModel : PageModel
    {
        private readonly l4.Data.DbConnection _context;

        public IndexModel(l4.Data.DbConnection context)
        {
            _context = context;
        }

        public IList<BookOutOfStorage> BookOutOfStorage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookOutOfStorages != null)
            {
                BookOutOfStorage = await _context.BookOutOfStorages
                .Include(b => b.Book)
                .Include(b => b.Person).ToListAsync();
            }
        }
    }
}
