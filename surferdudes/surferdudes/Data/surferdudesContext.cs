using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using surferdudes.Models;

namespace surferdudes.Models
{
    public class surferdudesContext : DbContext
    {
        public surferdudesContext (DbContextOptions<surferdudesContext> options)
            : base(options)
        {
        }

        public DbSet<surferdudes.Models.Product> Product { get; set; }

        public DbSet<surferdudes.Models.Contact> Contact { get; set; }

        public DbSet<surferdudes.Models.FAQ> FAQ { get; set; }

        public DbSet<surferdudes.Models.Nieuwsbriefmodel> Nieuwsbriefmodel { get; set; }
    }
}
