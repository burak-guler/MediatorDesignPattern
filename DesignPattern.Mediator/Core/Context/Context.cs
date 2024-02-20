using DesignPattern.Mediator.Core.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.Core.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MQSCLH4\\SQLEXPRESS; Database=MediatorDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        public DbSet<Product> Products { get; set; }
    }
}
