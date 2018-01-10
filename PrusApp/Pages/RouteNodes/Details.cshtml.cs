using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrusApp.Data;
using PrusApp.Models;

namespace PrusApp.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly PrusApp.Data.PrusContext _context;

        public DetailsModel(PrusApp.Data.PrusContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
