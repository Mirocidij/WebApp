using EasyRepository.ModelBase;

namespace Asp.Net_React_Redux_app.Models {
    public class Order : Entity<long> {
        public long UserId { get; set; }
        public User User { get; set; }
    }
}