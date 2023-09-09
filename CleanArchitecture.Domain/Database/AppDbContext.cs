using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Database
{
    public class AppDbContext : DbContext
    {
        private string _connectionString;

        public AppDbContext(string configuration)
        {
            _connectionString = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .HasQueryFilter(u => !u.IsDeleted);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }


        public DbSet<UserAccount> UserAccount { get; set; }


        #region private override
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(_connectionString);
        }
        #endregion
    }
}
