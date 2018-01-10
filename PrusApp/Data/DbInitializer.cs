using PrusApp.Models;
using System;
using System.Linq;

namespace PrusApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PrusContext context)
        {
            

            
            if (context.Packages.Any())
            {
                return;   
            }

            var packages = new Package[]
            {
            new Package{PackageNumID = 1, Type="Fragile"},
            new Package{PackageNumID = 2, Type="Heavy"},
            new Package{PackageNumID = 3, Type="Large"},
            new Package{PackageNumID = 4, Type="Large Envelope"},
            new Package{PackageNumID = 5, Type="Padded Envelope"},
            new Package{PackageNumID = 6, Type="Heavy"},
            new Package{PackageNumID = 7, Type="Fragile"},
            new Package{PackageNumID = 8, Type="Unknown"}
            };
            foreach (Package p in packages)
            {
                context.Packages.Add(p);
            }
            context.SaveChanges();

            var distributionCenters = new DistributionCenter[]
            {
            new DistributionCenter{ID=1050,Name="Center1",PhoneNum="555-685-5689"},
            new DistributionCenter{ID=1060,Name="Center2",PhoneNum="555-685-5690"},
            new DistributionCenter{ID=1070,Name="Center3",PhoneNum="555-685-5691"},
            new DistributionCenter{ID=1080,Name="Center4",PhoneNum="555-685-5692"},
            new DistributionCenter{ID=1090,Name="Center5",PhoneNum="555-685-5693"},
            new DistributionCenter{ID=1150,Name="Center6",PhoneNum="555-685-5694"},
            new DistributionCenter{ID=1160,Name="Center7",PhoneNum="555-685-5695"},
            new DistributionCenter{ID=1170,Name="Center8",PhoneNum="555-685-5696"},

            };
            foreach (DistributionCenter c in distributionCenters)
            {
                context.DistributionCenters.Add(c);
            }
            context.SaveChanges();

            var routeNodes = new RouteNode[]
            {
            new RouteNode{PackageNumID=1,DistributionCenterID=1050,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")},
            new RouteNode{PackageNumID=1,DistributionCenterID=1060,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM") },
            new RouteNode{PackageNumID=2,DistributionCenterID=1050,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")},
            new RouteNode{PackageNumID=2,DistributionCenterID=1070,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")},
            new RouteNode{PackageNumID=3,DistributionCenterID=1080,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")},
            new RouteNode{PackageNumID=4,DistributionCenterID=1150,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")},
            new RouteNode{PackageNumID=5,DistributionCenterID=1090,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")},
            new RouteNode{PackageNumID=5,DistributionCenterID=1160,Arrival=DateTime.Parse("01/01/2017 01:30PM"), Departure=DateTime.Parse("01/01/2017 01:30PM")}
            };
            foreach (RouteNode e in routeNodes)
            {
                context.RouteNodes.Add(e);
            }
            context.SaveChanges();
        }
    }
}