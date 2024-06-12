using Microsoft.EntityFrameworkCore;

namespace MVCStartApp.Models.Db
{
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserRequest> UserRequest { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //жесткая привязка сущности к таблице в БД
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserPost>().ToTable("UserPosts");
            modelBuilder.Entity<UserRequest>().ToTable("UserRequest");
        }
    }
}
