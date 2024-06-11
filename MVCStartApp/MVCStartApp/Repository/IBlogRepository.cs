using MVCStartApp.Models.Db;

namespace MVCStartApp.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
