using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrusApp.Models
{
    public class Package
    {
        [Key]
        public int PackageNumID { get; set; }
        public string Type { get; set; }
        public string Product { get; set; }

        public ICollection<RouteNode> RouteNodes { get; set; }
    }
}
