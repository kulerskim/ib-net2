using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeablogClear.Models
{
    public class IbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }


        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Reply && entry.State == System.Data.EntityState.Added)
                {
                    ((Reply)entry.Entity).CreatedAt = DateTime.Now;

                }
            }

            return base.SaveChanges();
        }
    }


}