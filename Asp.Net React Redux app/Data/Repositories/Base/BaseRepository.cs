using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_React_Redux_app.Data.Repositories.Base {
    public abstract class
        BaseRepository<TType, TTypeId, TDataContext> : IBaseRepository<TType, TTypeId>
        where TType : Entity<TTypeId>
        where TDataContext : DbContext {
        protected TDataContext DataContext { get; private set; }
        protected DbSet<TType> DbSet { get; private set; }

        public BaseRepository(
            TDataContext dataContext
        ) {
            DataContext = dataContext;

            var property = DataContext
                .GetType()
                .GetProperties()
                .SingleOrDefault(x => x.PropertyType == typeof(DbSet<TType>));

            try {
                DbSet = (DbSet<TType>)property.GetValue(dataContext);
            } catch (Exception e) {
                throw new TypeInitializationException(
                    nameof(BaseRepository<TType, TTypeId, TDataContext>), e);
            }
        }

        public virtual IList<TType> GetAll() {
            return DbSet.Where(x => !x.IsDeleted).ToList();
        }

        public virtual async Task<IList<TType>> GetAllAsync(
            CancellationToken cancellationToken = new CancellationToken()
        ) {
            return await DbSet.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
        }

        public virtual TType GetById(TTypeId id) {
            var result = DbSet.Find(id);
            if (result.IsDeleted) {
                return null;
            }

            return result;
        }

        public virtual async Task<TType> GetByIdAsync(
            TTypeId id,
            CancellationToken cancellationToken = new CancellationToken()
        ) {
            var result = await DbSet.FindAsync(id, cancellationToken);
            if (result.IsDeleted) {
                return null;
            }

            return result;
        }

        public virtual bool Create(TType param) {
            DbSet.Add(param);
            return DataContext.SaveChanges() > 0;
        }

        public virtual async Task<bool> CreateAsync(
            TType param,
            CancellationToken cancellationToken = new CancellationToken()
        ) {
            await DbSet.AddAsync(param);
            return await DataContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public virtual void Delete(TType param) {
            if (param.IsDeleted) {
                return;
            }

            param.IsDeleted = true;
            DbSet.Update(param);
        }
    }
}