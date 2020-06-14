using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EasyRepository.ModelBase;

namespace EasyRepository.Repositories {
    public interface IBaseRepository<TType, TTypeId>
        where TType : Entity<TTypeId> {
        IList<TType> GetAll();

        Task<IList<TType>> GetAllAsync(
            CancellationToken cancellationToken = new CancellationToken());

        TType GetById(TTypeId id);

        Task<TType> GetByIdAsync(TTypeId id,
            CancellationToken cancellationToken = new CancellationToken());

        bool Create(TType param);

        Task<bool> CreateAsync(TType param,
            CancellationToken cancellationToken = new CancellationToken());

        bool Update(TType param);

        Task<bool> UpdateAsync(TType param,
            CancellationToken cancellationToken = new CancellationToken());

        void Delete(TType param);
    }
}