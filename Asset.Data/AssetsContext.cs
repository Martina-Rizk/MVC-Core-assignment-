using Microsoft.EntityFrameworkCore;
using System;
using Assets.Domain;

namespace Assets.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext() : base() { }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=Asset;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );
            modelBuilder.Entity<Asset>().HasData(
                new Asset 
                { 
                    Id = 1, 
                    TagNumber = "mnbv-6541-mn12", 
                    AssetTypeId = 3, 
                    Manufacturer = "Cisco", 
                    Model = "CP-8861", 
                    Description = "business-class collaboration endpoint", 
                    SerialNumber = "3216954789216"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "okmh-54xb-mn63",
                    AssetTypeId = 2,
                    Manufacturer = "LG",
                    Model = "27GL650F-B",
                    Description = "Compatible monitor, eliminating screen tearing and minimizing stutter for a smoother",
                    SerialNumber = "9547863214587"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "pokh-654p-mbn9",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Model = "Latitude 5500",
                    Description = "The Fully Featured Laptop w/ Intel Core for Professionals",
                    SerialNumber = "9632147852314"
                }
            );

        }
    }
}
