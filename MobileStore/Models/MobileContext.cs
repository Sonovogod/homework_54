using Microsoft.EntityFrameworkCore;
using MobileStore.Services.Abstractions;

namespace MobileStore.Models;

public class MobileContext : DbContext
{
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    
    private readonly IFileService _fileService;

    public MobileContext(
        DbContextOptions<MobileContext> options, IFileService fileService) : base(options)
    {
        _fileService = fileService;
    }

    public override int SaveChanges()
    {
        DeleteFile();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>().HasQueryFilter(p => !p.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        DeleteFile();
        return await base.SaveChangesAsync(token);
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