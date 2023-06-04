using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityGarden.Models;

namespace CommunityGarden.Data
{
    public class CommunityGardenContext : DbContext
    {
        public CommunityGardenContext (DbContextOptions<CommunityGardenContext> options)
            : base(options)
        {
        }

        public DbSet<CommunityGarden.Models.User> User { get; set; } = default!;

        public DbSet<CommunityGarden.Models.Garden>? Garden { get; set; }

        public DbSet<CommunityGarden.Models.Chat>? Chat { get; set; }

        public DbSet<CommunityGarden.Models.Message>? Message { get; set; }

        public DbSet<CommunityGarden.Models.Badge>? Badge { get; set; }

        public DbSet<CommunityGarden.Models.Achievement>? Achievement { get; set; }

        public DbSet<CommunityGarden.Models.GardenEvent>? GardenEvent { get; set; }

        public DbSet<CommunityGarden.Models.GardenExpert>? GardenExpert { get; set; }

        public DbSet<CommunityGarden.Models.GardenUser>? GardenUser { get; set; }

        public DbSet<CommunityGarden.Models.Herb>? Herb { get; set; }

        public DbSet<CommunityGarden.Models.Plant>? Plant { get; set; }

        public DbSet<CommunityGarden.Models.Plot>? Plot { get; set; }

        public DbSet<CommunityGarden.Models.PlotUser>? PlotUser { get; set; }

    }
}
