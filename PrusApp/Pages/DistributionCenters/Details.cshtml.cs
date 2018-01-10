using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrusApp.Data;
using PrusApp.Models;

namespace PrusApp.Pages.DistributionCenters
{
    public class DetailsModel : PageModel
    {
        private readonly PrusApp.Data.PrusContext _context;

        public DetailsModel(PrusApp.Data.PrusContext context)
        {
            _context = context;
        }

        public DistributionCenter DistributionCenter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DistributionCenter = await _context.DistributionCenters.SingleOrDefaultAsync(m => m.ID == id);

            if (DistributionCenter == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
