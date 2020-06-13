using System;
using Asp.Net_React_Redux_app.Data.Repositories.Base;

namespace Asp.Net_React_Redux_app.Models {
    public class User : Entity<long>, IHasCreatingDateTime {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime CreatingDatetime { get; set; }
        public string Email { get; set; }
        
        public long? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}