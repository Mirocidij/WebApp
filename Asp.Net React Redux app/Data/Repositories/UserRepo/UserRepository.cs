using Asp.Net_React_Redux_app.Models;
using EasyRepository.Repositories;

namespace Asp.Net_React_Redux_app.Data.Repositories.UserRepo {
    public class UserRepository : BaseRepository<User, long, DataContext>, IUserRepository {
        public UserRepository(DataContext dataContext) : base(dataContext) { }
    }
}