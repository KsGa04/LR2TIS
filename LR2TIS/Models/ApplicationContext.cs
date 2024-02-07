using LR2TIS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Users.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
        base(options)
        {
            Database.EnsureCreated();
        }
    }
}
