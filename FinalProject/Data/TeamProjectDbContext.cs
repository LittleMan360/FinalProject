namespace FinalProject.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TeamProjectDbContext : DbContext
    {
        public TeamProjectDbContext(DbContextOptions<TeamProjectDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<FavoriteBreakfast> FavoriteBreakfasts { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
