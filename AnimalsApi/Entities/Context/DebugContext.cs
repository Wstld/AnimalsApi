using System;
using AnimalsApi.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AnimalsApi.Entities.Context
{
    public class DebugContext : DbContext
    {
        IConfiguration _config;

        public DebugContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(_config["ConnectionStrings:Default"],
                ServerVersion.AutoDetect(_config["ConnectionStrings:Default"])
                );
        }

    }
}
