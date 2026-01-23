using Microsoft.EntityFrameworkCore;
using WebApi_Func.Domain.Entities;

namespace WebApi_Func.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Matricula).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();
            });
        }
    }
}
