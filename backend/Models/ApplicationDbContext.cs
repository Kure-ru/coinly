using coinly.Models;
using Microsoft.EntityFrameworkCore;

namespace coinly;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
    
    public DbSet<User> Users { get; set; }
}