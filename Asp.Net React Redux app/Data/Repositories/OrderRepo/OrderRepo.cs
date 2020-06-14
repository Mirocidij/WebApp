using Asp.Net_React_Redux_app.Models;
using EasyRepository.Repositories;

namespace Asp.Net_React_Redux_app.Data.Repositories.OrderRepo {
    public class OrderRepo : BaseRepository<Order, long, DataContext>, IOrderRepo {
        public OrderRepo(DataContext dataContext) : base(dataContext) { }
    }
}