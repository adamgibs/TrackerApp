using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrusApp.Models
{
    public class DistributionCenter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }

        public ICollection<RouteNode> RouteNodes { get; set; }
    }
}
