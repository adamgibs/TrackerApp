using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrusApp.Models
{
    public class RouteNode
    {
        public int RouteNodeID { get; set; }
        public int DistributionCenterID { get; set; }
        public int PackageNumID { get; set;}
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public DistributionCenter DistributionCenter { get; set; }
        public Package Package { get; set; }
    }
}
