using Asp.Net_React_Redux_app.Data.Repositories.Base;
using Asp.Net_React_Redux_app.Models;

namespace Asp.Net_React_Redux_app.Data.Repositories.PostRepo {
    public interface IPostRepository : IBaseRepository<Post, long> { }
}