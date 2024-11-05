using Microsoft.EntityFrameworkCore;
using RealTimeApp.Models;

namespace RealTimeApp;
public class RealTimeAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=ProductDbwindowservice;user=root;password=root",
            new MySqlServerVersion(new Version(8, 0, 21)));
    }

    public DbSet<Products> Products { get; set; }

}