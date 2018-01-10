using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrusApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PrusApp.Data
{
    public class PrusContext : DbContext
    {
        public PrusContext(DbContextOptions<PrusContext> options) : base(options) { }

        public DbSet<Package> Packages { get; set; }
        public DbSet<RouteNode> RouteNodes { get; set; }
        public DbSet<DistributionCenter> DistributionCenters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>().ToTable("Package");
            modelBuilder.Entity<RouteNode>().ToTable("RouteNode");
            modelBuilder.Entity<DistributionCenter>().ToTable("DistributionCenter");
        }


    }
}
