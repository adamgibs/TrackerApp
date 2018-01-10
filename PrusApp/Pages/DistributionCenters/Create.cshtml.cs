using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrusApp.Data;
using PrusApp.Models;

namespace PrusApp.Pages.DistributionCenters
{
    public class CreateModel : PageModel
    {
        private readonly PrusApp.Data.PrusContext _context;

        public CreateModel(PrusApp.Data.PrusContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DistributionCenter DistributionCenter { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DistributionCenters.Add(DistributionCenter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}