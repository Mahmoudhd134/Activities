using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
   
}