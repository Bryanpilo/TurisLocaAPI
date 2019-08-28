using Microsoft.EntityFrameworkCore;
using TurisLocAPI.API.Models;

namespace TurisLocAPI.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { } 

        public DbSet<User> Users { get; set; }

//Data that will be loaded when we generate the db update
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>().HasData(new User
        //     {
        //         Id=2,
        //         Name="bryan",
        //         Password="123"
 
        //     }, new User
        //     {
        //         Id=1,
        //         Name="bryan",
        //         Password="123"
        //     });
        // }
        
    }
}