using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrusApp.Data;
using PrusApp.Models;

namespace PrusApp.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly PrusApp.Data.PrusContext _context;

        public EditModel(PrusApp.Data.PrusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RouteNode RouteNode { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RouteNode = await _context.RouteNodes
                .Include(r => r.DistributionCenter)
                .Include(r => r.Package).SingleOrDefaultAsync(m => m.RouteNodeID == id);

            if (RouteNode == null)
            {
                return NotFound();
            }
           ViewData["DistributionCenterID"] = new SelectList(_context.DistributionCenters, "ID", "ID");
           ViewData["PackageNumID"] = new SelectList(_context.Packages, "PackageNumID", "PackageNumID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RouteNode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Index");
        }
    }
}
