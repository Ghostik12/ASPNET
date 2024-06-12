using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Repository
{
    public class UserRequest1 : IUserRequest
    {
        private readonly BlogContext _blogContext;

        public UserRequest1(BlogContext blogContext) 
        {
            _blogContext = blogContext;
        }

        public async Task AddRequest(Models.Db.UserRequest userRequest)
        {
            var entry = _blogContext.Entry(userRequest);
            if (entry.State == EntityState.Detached)
                _blogContext.UserRequest.AddAsync(userRequest);

            await _blogContext.SaveChangesAsync();
        }

        public async Task<UserRequest[]> GetRequests()
        {
            return await _blogContext.UserRequest.ToArrayAsync();
        }
    }
}
