using Asp.Net_React_Redux_app.Models;
using EasyRepository.Repositories;

namespace Asp.Net_React_Redux_app.Data.Repositories.PostRepo {
    public class PostRepository : BaseRepository<Post, long, DataContext>, IPostRepository {
        public PostRepository(DataContext dataContext) : base(dataContext) { }
    }
}