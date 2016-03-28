using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPositive.Models;

namespace MPositive.DAL
{
    public class SyncApiContext : DbContext
    {
        public SyncApiContext() : base("DefaultConnection")
        { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
