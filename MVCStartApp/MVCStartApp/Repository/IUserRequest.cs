
namespace MVCStartApp.Repository
{
    public interface IUserRequest
    {
        Task AddRequest(Models.Db.UserRequest request);
        Task<Models.Db.UserRequest[]> GetRequests();
    }
}
