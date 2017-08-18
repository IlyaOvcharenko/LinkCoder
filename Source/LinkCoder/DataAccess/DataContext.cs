using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>().Property(t => t.OriginalLink).IsRequired();
            modelBuilder.Entity<Link>().Property(t => t.CreateDateTime).IsRequired();
            modelBuilder.Entity<Link>().Property(t => t.UserId).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
