using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext) 
        {
            _blogContext = blogContext;
        }

        public async Task AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.JoinDate = DateTime.Now;

            var entry = _blogContext.Entry(user);
            if (entry.State == EntityState.Detached) 
                await _blogContext.Users.AddAsync(user);

            await _blogContext.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _blogContext.Users.ToArrayAsync();
        }
    }
}
