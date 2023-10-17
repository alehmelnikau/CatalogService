using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<CategoryItem> CategoryItems => Set<CategoryItem>();
}
