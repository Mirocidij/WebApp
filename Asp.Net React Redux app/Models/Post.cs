using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using EasyRepository.ModelBase;

namespace Asp.Net_React_Redux_app.Models {
    public class Post : Entity<long> {
        [NotNull]
        [MaxLength(50)]
        public string Title { get; set; }

        [NotNull]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}