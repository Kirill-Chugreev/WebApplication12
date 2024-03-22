using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication12.Models;

namespace WebApplication12
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Nicola", Age = 12 },
                new User { Id = 2, Name = "Bob", Age = 22 },
                new User { Id = 3, Name = "John", Age = 19 },
                new User { Id = 4, Name = "Kirill",Age = 20});
        }

    }
    
}
