using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC_Building_Application.Data;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Helper
{
    public static class PopulateDb
    {
        public static void Populate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }

        public static void SeedData(DataContext context)
        {
            Console.WriteLine("Running SeedData Method...");
            context.Database.Migrate();

            if (!context.Photos.Any())
            {
                Console.WriteLine("Adding Picture for Annonymous Users to the database!");
                context.Photos.AddRange
                (
                    new Photo() 
                        { 
                            Url = "https://i1.sndcdn.com/avatars-000437232558-yuo0mv-t500x500.jpg",
                            Description = "Anonymous User Photo",
                            DateAdded = DateTime.Now,
                            PublicId = "0"
                        }                               
                );
            }
            else
            {
                Console.WriteLine("There are some photos in the database!");
            }

            if(!context.SocketTypes.Any())
            {
                Console.WriteLine("Adding the most popular socket types to the database!");
                context.SocketTypes.AddRange
                (
                    new SocketType() {Name = "AM4"},
                    new SocketType() { Name = "TR4" },
                    new SocketType() { Name = "sTRX4" },
                    new SocketType() { Name = "LGA1150" },
                    new SocketType() { Name = "LGA1151" },
                    new SocketType() { Name = "LGA1155" },
                    new SocketType() { Name = "LGA2066" },
                    new SocketType() { Name = "Other" }
                );
            }
            else
            {
                Console.WriteLine("There are some Socket Types in the database!");
            }

            if(!context.Manufacturers.Any())
            {
                Console.WriteLine("Adding the most popular Manufacturers to the database!");
                context.AddRange
                (
                    new Manufacturer() { Name = "AMD", City = "Santa Clara, CA", Country = "U.S.A"},
                    new Manufacturer() { Name = "Intel", City = "Santa Clara, CA", Country = "U.S.A" },
                    new Manufacturer() { Name = "Asus", City = "Taipei", Country = "Taiwan" },
                    new Manufacturer() { Name = "MSI", City = "New Taipei", Country = "Taiwan" },
                    new Manufacturer() { Name = "Nvidia", City = "Santa Clara, CA", Country = "U.S.A" },
                    new Manufacturer() { Name = "NZXT", City = "City of Industry, CA", Country = "U.S.A" },
                    new Manufacturer() { Name = "EVGA Corporation", City = "Santa Clara, CA", Country = "U.S.A" },
                    new Manufacturer() { Name = "Samsung", City = "Seoul", Country = "South Korea" },
                    new Manufacturer() { Name = "Kingston Technology", City = "Fountain Valley, CA", Country = "U.S.A" },
                    new Manufacturer() { Name = "Micron Technology", City = "Boise, ID", Country = "U.S.A" },
                    new Manufacturer() { Name = "Cooler Master", City = "New Taipei", Country = "Taiwan" },
                    new Manufacturer() { Name = "Other", City = "N/A", Country = "N/A" }
                );
            }
            else
            {
                Console.WriteLine("There are some Manufacturers in the database!");
            }

            if(!context.StorageTypes.Any())
            {
                Console.WriteLine("Adding the most popular Storage types to the database!");
                context.AddRange
                (
                    new StorageType() { Name = "M.2 SSD"},
                    new StorageType() { Name = "SATA SSD"},
                    new StorageType() { Name = "5400 HDD" },
                    new StorageType() { Name = "7200 HDD" }
                );
            }
            else
            {
                Console.WriteLine("There are some Storage Types in the database!");
            }

            context.SaveChanges();
        }
    }
}
