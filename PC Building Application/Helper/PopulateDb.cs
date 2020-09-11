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
                        PublicId = "1"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Desktop_computer_clipart_-_Yellow_theme.svg/1280px-Desktop_computer_clipart_-_Yellow_theme.svg.png",
                        Description = "PC Photo",
                        DateAdded = DateTime.Now,
                        PublicId = "2"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/hr/thumb/7/7c/AMD_Logo.svg/1280px-AMD_Logo.svg.png",
                        Description = "AMD Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "3"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Intel_logo_%282020%2C_light_blue%29.svg/1280px-Intel_logo_%282020%2C_light_blue%29.svg.png",
                        Description = "Intel Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "4"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/81/AsusTek_logo.svg/1280px-AsusTek_logo.svg.png",
                        Description = "Asus Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "5"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/en/1/1f/2019-msi-logo.png",
                        Description = "MSI Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "6"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/hr/c/cc/400px-Nvidia_logo.svg.png",
                        Description = "Nvidia Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "7"
                    }, 
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/NZXT.svg/1280px-NZXT.svg.png",
                        Description = "NZXT Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "8"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/EVGA_Logo.svg/1280px-EVGA_Logo.svg.png",
                        Description = "EVGA Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "9"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Samsung_wordmark.svg/1280px-Samsung_wordmark.svg.png",
                        Description = "Samsung Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "10"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/en/thumb/7/74/Kingston_Technology_logo.svg/1280px-Kingston_Technology_logo.svg.png",
                        Description = "Kingston Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "11"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9b/Micron_Technology_logo.svg/1280px-Micron_Technology_logo.svg.png",
                        Description = "Micron Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "12"
                    },
                    new Photo()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ed/Cooler_Master_black_logo.svg/1024px-Cooler_Master_black_logo.svg.png",
                        Description = "Cooler Master Logo",
                        DateAdded = DateTime.Now,
                        PublicId = "13"
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
                    new Manufacturer() { Name = "AMD", City = "Santa Clara, CA", Country = "U.S.A", PhotoId = 3},
                    new Manufacturer() { Name = "Intel", City = "Santa Clara, CA", Country = "U.S.A", PhotoId = 4 },
                    new Manufacturer() { Name = "Asus", City = "Taipei", Country = "Taiwan", PhotoId = 5 },
                    new Manufacturer() { Name = "MSI", City = "New Taipei", Country = "Taiwan", PhotoId = 6 },
                    new Manufacturer() { Name = "Nvidia", City = "Santa Clara, CA", Country = "U.S.A", PhotoId = 7 },
                    new Manufacturer() { Name = "NZXT", City = "City of Industry, CA", Country = "U.S.A", PhotoId = 8 },
                    new Manufacturer() { Name = "EVGA Corporation", City = "Santa Clara, CA", Country = "U.S.A", PhotoId = 9 },
                    new Manufacturer() { Name = "Samsung", City = "Seoul", Country = "South Korea", PhotoId = 10 },
                    new Manufacturer() { Name = "Kingston Technology", City = "Fountain Valley, CA", Country = "U.S.A", PhotoId = 11 },
                    new Manufacturer() { Name = "Micron Technology", City = "Boise, ID", Country = "U.S.A", PhotoId = 12 },
                    new Manufacturer() { Name = "Cooler Master", City = "New Taipei", Country = "Taiwan", PhotoId = 13 },
                    new Manufacturer() { Name = "Other", City = "N/A", Country = "N/A", PhotoId = 2 }
                );
            }
            else
            {
                Console.WriteLine("There are some Manufacturers in the database!");
            }

            if(!context.StorageTypes.Any())
            {
                Console.WriteLine("Adding the most used storage types to the database!");
                context.AddRange
                (
                    new StorageType() { Name = "M.2 SSD"},
                    new StorageType() { Name = "SATA SSD" },
                    new StorageType() { Name = "5400 HDD" },
                    new StorageType() { Name = "7200 SSD" }
                );
            }
            else
            {
                Console.WriteLine("There are some storage types in the database!");
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("Adding default user to the database!");
                context.Users.Add(new User() { Id= "anonymous", UserName = "Anonymous user", Email = "anonymous@buildit.com", EmailConfirmed = true, PhotoId = 1 });
            }
            else
            {
                Console.WriteLine("There are some users in the database!");
            }

            context.SaveChanges();
        }
    }
}
