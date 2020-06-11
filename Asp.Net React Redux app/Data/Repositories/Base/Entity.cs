using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Asp.Net_React_Redux_app.Data.Repositories.Base {
    public abstract class Entity<TType> {
        [Key]
        public TType Id { get; set; }
        [NotNull]
        public bool IsDeleted { get; set; }
    }
}