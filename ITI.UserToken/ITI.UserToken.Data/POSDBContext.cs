using ITI.UserToken.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.UserToken.Data
{
    public class POSDBContext : DbContext
    {
        public POSDBContext():base("name = POSDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
