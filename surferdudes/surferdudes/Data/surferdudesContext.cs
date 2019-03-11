using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace surferdudes.Models
{
    public class surferdudesContext : DbContext
    {
        public surferdudesContext (DbContextOptions<surferdudesContext> options)
            : base(options)
        {
        }

        public DbSet<surferdudes.Models.Product> Product { get; set; }
    }
}
