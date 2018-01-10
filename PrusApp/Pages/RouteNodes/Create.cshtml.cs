using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrusApp.Data;
using PrusApp.Models;

namespace PrusApp.Pages.Courses
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
        ViewData["DistributionCenterID"] = new SelectList(_context.DistributionCenters, "ID", "ID");
        ViewData["PackageNumID"] = new SelectList(_context.Packages, "PackageNumID", "PackageNumID");
            return Page();
        }

        [BindProperty]
        public RouteNode RouteNode { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RouteNodes.Add(RouteNode);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}