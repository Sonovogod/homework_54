using Microsoft.EntityFrameworkCore;
using MobileStore.Services.Abstractions;

namespace MobileStore.Models;

public class MobileContext : DbContext
{
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Brand> Brands { get; set; }
    private readonly IFileService _fileService;

    public MobileContext(
        DbContextOptions<MobileContext> options, IFileService fileService) : base(options)
    {
        _fileService = fileService;
    }

    public override int SaveChanges()
    {
        SetOrderCreationDateTime();
        DeleteFile();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(p => !p.Phone.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        SetOrderCreationDateTime();
        DeleteFile();
        return await base.SaveChangesAsync(token);
    }

    private void SetOrderCreationDateTime()
    {
        foreach (var entry in ChangeTracker.Entries<Order>())
        {
            if (entry.State is not (EntityState.Added or EntityState.Modified)) continue;
            Order order = entry.Entity;
            switch (entry.State)
            {
                case EntityState.Added:
                {
                    order.CreatedAt = DateTime.Now;
                    break;
                }
                case EntityState.Modified:
                {
                    order.UpdatedAt = DateTime.Now;
                    break;
                }
            }
        }
    }

    private void DeleteFile()
    {
        foreach (var entry in ChangeTracker.Entries<Phone>())
        {
            if (entry.State is not EntityState.Deleted) continue;
            Phone phone = entry.Entity;
            _fileService.Remove($"{phone.Brand.Name}_{phone.Title}.txt");
        }
    }
}