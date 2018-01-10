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
    public class IndexModel : PageModel
    {
        private readonly PrusApp.Data.PrusContext _context;

        public IndexModel(PrusApp.Data.PrusContext context)
        {
            _context = context;
        }

        public IList<DistributionCenter> DistributionCenter { get;set; }

        public async Task OnGetAsync()
        {
            DistributionCenter = await _context.DistributionCenters.ToListAsync();
        }
    }
}
