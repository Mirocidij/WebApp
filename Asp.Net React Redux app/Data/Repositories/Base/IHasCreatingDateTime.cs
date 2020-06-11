using System;

namespace Asp.Net_React_Redux_app.Data.Repositories.Base {
    public interface IHasCreatingDateTime {
        public DateTime CreatingDatetime { get; set; }
    }
}