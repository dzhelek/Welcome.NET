using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<DatabaseLogger> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DatabaseLogger>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };
            var user2 = new DatabaseUser()
            {
                Id = 2,
                Names = "Jane Doe",
                Password = "1234",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(1)
            };
            var user3 = new DatabaseUser()
            {
                Id = 3,
                Names = "Jack Doe",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(20)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
            modelBuilder.Entity<DatabaseUser>().HasData(user2);
            modelBuilder.Entity<DatabaseUser>().HasData(user3);
        }
    }
}
