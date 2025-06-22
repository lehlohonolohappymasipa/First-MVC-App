using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using MVCLearn.Models;

namespace MVCLearn.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many relationship
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            { 
                ic.ItemId, 
                ic.ClientId 
            });
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Client).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ClientId);

            //one to one relationship
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 15, Name = "microphone", Price = 40, SerialNumberId = 10 });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150", ItemId = 15 });
            base.OnModelCreating(modelBuilder);

            //one to many relationship
            modelBuilder.Entity<Category>().HasData(
                new Category { Id =1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Leader> Leader { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}
