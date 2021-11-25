using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public static class DbInitialize
    {
        public static void Initialize(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Description = "Admin role",
                    Name = "ADMIN"

                },
                new Role()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Description = "Member role",
                    Name = "MEMBER"
                });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("FCA74D71-B4B1-418B-8197-B452299DDCA4"),
                    Address = "Ho Chi Minh",
                    DateCreated = DateTime.Now,
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    IsActive = true,
                    IsDelete = false,
                    LastName = "Mr",
                    PhoneNumber = "0987654321",
                    Username = "admin",
                    Password = "7676aaafb027c825bd9abab78b234070e702752f625b752e55e55b48e607e358" //admin@123
                },
                new User()
                {
                    Id = new Guid("38FC78CD-9722-4027-BA59-5F60EE12E5A7"),
                    Address = "Ho Chi Minh",
                    DateCreated = DateTime.Now,
                    Email = "user@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "User",
                    IsActive = true,
                    IsDelete = false,
                    LastName = "Mr",
                    PhoneNumber = "0981234567",
                    Username = "user",
                    Password = "dcb694aa0322f143ed970e275c807bf123bd5db4f73140b94ccc757f42dc8043" //user@123
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    RoleId = 1,
                    UserId = new Guid("FCA74D71-B4B1-418B-8197-B452299DDCA4")
                }, 
                new UserRole() 
                { 
                    RoleId = 2, 
                    UserId = new Guid("38FC78CD-9722-4027-BA59-5F60EE12E5A7") 
                });

            modelBuilder.Entity<Option>().HasData(
                new Option()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    NameOption = "S",
                    OptionGroup = ProductOptionGroup.Size
                },
                new Option()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    NameOption = "M",
                    OptionGroup = ProductOptionGroup.Size
                },
                new Option()
                {
                    Id = 3,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    NameOption = "L",
                    OptionGroup = ProductOptionGroup.Size
                },
                new Option()
                {
                    Id = 4,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    NameOption = "Black",
                    OptionGroup = ProductOptionGroup.Color
                },
                new Option()
                {
                    Id = 5,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    NameOption = "White",
                    OptionGroup = ProductOptionGroup.Color
                });

            modelBuilder.Entity<Menu>().HasData(
                new Menu()
                {
                    Id = 1,
                    Name = "Home",
                    DateCreated = DateTime.Now,
                    DisplayOrder = 1,
                    IsActive = true,
                    MenuType = MenuType.MainMenu,
                    Link = "/"
                },
                new Menu()
                {
                    Id = 2,
                    Name = "Shop",
                    DateCreated = DateTime.Now,
                    DisplayOrder = 2,
                    IsActive = true,
                    MenuType = MenuType.MainMenu,
                    Link = "/shop"
                },
                new Menu()
                {
                    Id = 3,
                    Name = "Blog",
                    DateCreated = DateTime.Now,
                    DisplayOrder = 3,
                    IsActive = true,
                    MenuType = MenuType.MainMenu,
                    Link = "/blog"
                },
                new Menu()
                {
                    Id = 4,
                    Name = "Contact",
                    DateCreated = DateTime.Now,
                    DisplayOrder = 4,
                    IsActive = true,
                    MenuType = MenuType.MainMenu,
                    Link = "/contact"
                },
                new Menu()
                {
                    Id = 5,
                    Name = "About",
                    DateCreated = DateTime.Now,
                    DisplayOrder = 5,
                    IsActive = true,
                    MenuType = MenuType.MainMenu,
                    Link = "/about"
                });

            modelBuilder.Entity<Tag>().HasData(
                new Tag()
                {
                    DateCreated = DateTime.Now,
                    Id = 1,
                    IsActive = true,
                    TagName = "Clothing"
                },
                new Tag()
                {
                    DateCreated = DateTime.Now,
                    Id = 2,
                    IsActive = true,
                    TagName = "Accessories"
                }, new Tag()
                {
                    DateCreated = DateTime.Now,
                    Id = 3,
                    IsActive = true,
                    TagName = "Fashion"
                });
        }
    }
}

