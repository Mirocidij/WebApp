using System;
using System.Collections.Generic;
using EasyRepository.ModelBase;

namespace Asp.Net_React_Redux_app.Models {
    public class User : Entity<long>, IHasCreatingDateTime {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime CreatingDatetime { get; set; }
        public string Email { get; set; }
        
        public IList<Order> Orders { get; set; }
        
        public long? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}