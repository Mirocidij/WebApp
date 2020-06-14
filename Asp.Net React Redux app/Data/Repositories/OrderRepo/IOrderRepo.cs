using Asp.Net_React_Redux_app.Models;
using EasyRepository.Repositories;

namespace Asp.Net_React_Redux_app.Data.Repositories.OrderRepo {
    public interface IOrderRepo : IBaseRepository<Order, long> {
        
    }
}