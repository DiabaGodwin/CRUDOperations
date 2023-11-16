using CRUDOperation.Application.Dtos;
using CRUDOperations.Domain.Models;
using CRUDOperations.Infrastructure.Dtos;
using CRUDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperations.Infrastructure.Models
{
    public class BrandDbContext: DbContext
    {
        public BrandDbContext(DbContextOptions<BrandDbContext> options):base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandReadDto> BrandReadDtos { get; set; }
        public DbSet<BrandCreateDto> BrandCreateDtos { get; set; }
        public DbSet<BrandUpdateDto> BrandUpdateDtos { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BrandReadDto>().HasNoKey();
            modelBuilder.Entity<BrandCreateDto>().HasNoKey();
            modelBuilder.Entity<BrandUpdateDto>().HasNoKey();

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandIdpk);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

        }
    }
}
