﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess.Context
{
    public class NordaShopDbContextFactory : IDesignTimeDbContextFactory<NordaShopDbContext>
    {
        public NordaShopDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<NordaShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new NordaShopDbContext(optionsBuilder.Options);
        }
    }
}
