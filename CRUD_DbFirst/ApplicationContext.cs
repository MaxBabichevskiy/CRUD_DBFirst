using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_DbFirst
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\Максим\\Desktop\\ConsoleApp23\\bin\\Debug\\net7.0\\dbBank.db");
        }

    }
}
