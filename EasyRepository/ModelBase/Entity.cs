using System.ComponentModel.DataAnnotations;

namespace EasyRepository.ModelBase {
    public abstract class Entity<TType> {
        [Key]
        public TType Id { get; set; }
    }
}