using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net_React_Redux_app.Data.Repositories.Base {
    public interface IBaseRepository<TType, TTypeId>
        where TType : Entity<TTypeId> {
        IList<TType> GetAll();
        Task<IList<TType>> GetAllAsync(CancellationToken cancellationToken = new CancellationToken());
        TType GetById(TTypeId id);
        Task<TType> GetByIdAsync(TTypeId id, CancellationToken cancellationToken = new CancellationToken());
        bool Create(TType param);
        Task<bool> CreateAsync(TType param, CancellationToken cancellationToken = new CancellationToken());
    }
}