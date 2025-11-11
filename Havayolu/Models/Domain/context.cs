using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Havayolu.Models.Domain
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> opts) : base(opts)
        {

        }
        public DbSet<Person> persons { get; set; }
        public DbSet<Kullanici> kullanicilar { get; set; }
        public DbSet<Bilet> biletler { get; set; }
        public DbSet<Kart> kartlar { get; set; }

    }
}
