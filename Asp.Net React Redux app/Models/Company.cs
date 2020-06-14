using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyRepository.ModelBase;

namespace Asp.Net_React_Redux_app.Models {
    public class Company : Entity<long> {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
        public IList<User> Users { get; set; }
    }
}