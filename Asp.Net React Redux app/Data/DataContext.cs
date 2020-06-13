using Asp.Net_React_Redux_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_React_Redux_app.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}