using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kangaroo_api.Domains.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace kangaroo_api.shared.Configurations.DatabaseConfigurations;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } //The table names in database


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.email).IsUnique();
        }
    
}