using Microsoft.EntityFrameworkCore;
using MVCLearn.Models;

namespace MVCLearn.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) :base(options)
        { 
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
