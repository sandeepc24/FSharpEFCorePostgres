using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AppData
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        public Nullable<DateTime> DOB { get; set; }

        public IList<Address> Addresses { get; set; }

        public User()
        {
            Addresses = new List<Address>();
        }
    }

    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        [MaxLength(250)]
        public string Street { get; set; }

        [MaxLength(250)]
        public string Suburb { get; set; }

        [MaxLength(250)]
        public string City { get; set; }

        [MaxLength(250)]
        public string Country { get; set; }
    }

    public class PGContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(builder.GetConnectionString("DATABASE_URL"));
        }
    }
}
