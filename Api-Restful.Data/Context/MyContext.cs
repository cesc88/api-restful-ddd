using Microsoft.EntityFrameworkCore;
using Api_Restful.Domain.Entities;
using Api_Restful.Data.Mapping;

namespace Api_Restful.Data.Context
{
    public class MyContext : DbContext
    {
       DbSet<UserEntity> Users { get; set; }

       public MyContext(DbContextOptions<MyContext> options) : base (options) {}
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

       }
    }
}