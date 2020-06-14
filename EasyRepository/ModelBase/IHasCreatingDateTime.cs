using System;

namespace EasyRepository.ModelBase {
    public interface IHasCreatingDateTime {
        public DateTime CreatingDatetime { get; set; }
    }
}