using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLinqOneApp
{

    class City
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }

    class Country
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CapitalId { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CountryId { get; set; }
        public virtual List<Employee> Employees { get; set; } = new();

    }

    public class Position
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public virtual List<Employee> Employees { get; set; } = new();
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { set; get; }
        public virtual Company? Company { set; get; }
        public int? CompanyId { set; get; }
        public virtual Position? Position { set; get; }
        public int PositionId { set; get; }
    }
    internal class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ISC66B9\\MSSQLSERVER2022;Initial Catalog=CompanyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasQueryFilter(e => e.Age > 25);
        }
    }
}
