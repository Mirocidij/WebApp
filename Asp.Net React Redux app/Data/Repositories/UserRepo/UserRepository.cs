using Asp.Net_React_Redux_app.Data.Repositories.Base;
using Asp.Net_React_Redux_app.Models;

namespace Asp.Net_React_Redux_app.Data.Repositories.UserRepo {
    public class UserRepository : BaseRepository<User, long, DataContext>, IUserRepository {
        public UserRepository(DataContext dataContext) : base(dataContext) { }
    }
}