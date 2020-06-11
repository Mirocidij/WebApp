using Asp.Net_React_Redux_app.Data.Repositories.Base;
using Asp.Net_React_Redux_app.Models;

namespace Asp.Net_React_Redux_app.Data.Repositories.PostRepo {
    public class PostRepository : BaseRepository<Post, long, DataContext>, IPostRepository {
        public PostRepository(DataContext dataContext) : base(dataContext) { }
    }
}