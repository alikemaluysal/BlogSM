using Core.Auth;
using Core.DataAccess.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public AppDbContext()
    {

    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        IEnumerable<EntityEntry<Entity>> entries = ChangeTracker
            .Entries<Entity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (EntityEntry<Entity> entry in entries)
            _ = entry.State switch
            {
                EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow
            };
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        byte[] passwordHash, passwordSalt;

        HashingHelper.CreatePasswordHash("1234", out passwordHash, out passwordSalt);

        List<User> users = new List<User>()
        { 
            new User() { Id = 1, Username = "admin", Email = "admin@mail.com", Role = "Admin", CreatedDate = DateTime.Now, PasswordHash = passwordHash, PasswordSalt = passwordSalt},
            new User() { Id = 2, Username = "kemal", Email = "kemal@mail.com", Role = "Reader", CreatedDate = DateTime.Now, PasswordHash = passwordHash, PasswordSalt = passwordSalt},
        };


        List<Category> categories = new List<Category>() {
            new Category() { Id = 1, Name = "Bilim", CreatedDate= DateTime.Now},
            new Category() { Id = 2, Name = "Yazılım", CreatedDate= DateTime.Now},
            new Category() { Id = 3, Name = "Teknoloji", CreatedDate= DateTime.Now},
            new Category() { Id = 4, Name = "Sağlık", CreatedDate= DateTime.Now},
        
        };


        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Category>().HasData(categories);

    }
}
