using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrusApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrusApp.Pages.RouteNodes
{
    public class DistributionCenterNamePageModel : PageModel
    {
        public SelectList CenterNameSL { get; set; }

        public void PopulateCenterNameDropDownList(PrusContext _context, object selectedCenter = null)
        {
            var centerQuery = from c in _context.DistributionCenters
                              orderby c.Name
                              select c;
            CenterNameSL = new SelectList(centerQuery.AsNoTracking(), "ID", "Name", selectedCenter);
                                
              
        }
    }
}
