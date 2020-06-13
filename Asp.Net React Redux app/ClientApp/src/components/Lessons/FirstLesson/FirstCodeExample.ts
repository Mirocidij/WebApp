export const FirstCodeExample = () =>
  "using System;\n" +
  "using System.Collections.Generic;\n" +
  "using System.Linq;\n" +
  "using System.Threading;\n" +
  "using System.Threading.Tasks;\n" +
  "using Microsoft.EntityFrameworkCore;\n" +
  "\n" +
  "namespace Asp.Net_React_Redux_app.Data.Repositories.Base {\n" +
  "    public abstract class\n" +
  "        BaseRepository<TType, TTypeId, TDataContext> : IBaseRepository<TType, TTypeId>\n" +
  "        where TType : Entity<TTypeId>\n" +
  "        where TDataContext : DbContext {\n" +
  "        protected TDataContext DataContext { get; }\n" +
  "        protected DbSet<TType> DbSet { get; }\n" +
  "\n" +
  "        public BaseRepository(\n" +
  "            TDataContext dataContext\n" +
  "        ) {\n" +
  "            DataContext = dataContext;\n" +
  "\n" +
  "            var property = DataContext\n" +
  "                .GetType()\n" +
  "                .GetProperties()\n" +
  "                .SingleOrDefault(x => x.PropertyType == typeof(DbSet<TType>));\n" +
  "\n" +
  "            try {\n" +
  "                DbSet = (DbSet<TType>)property?.GetValue(dataContext);\n" +
  "            } catch (Exception e) {\n" +
  "                throw new TypeInitializationException(\n" +
  "                    nameof(BaseRepository<TType, TTypeId, TDataContext>), e);\n" +
  "            }\n" +
  "        }\n" +
  "\n" +
  "        public virtual IList<TType> GetAll() {\n" +
  "            return DbSet.Where(x => !x.IsDeleted).ToList();\n" +
  "        }\n" +
  "\n" +
  "        public virtual async Task<IList<TType>> GetAllAsync(\n" +
  "            CancellationToken cancellationToken = new CancellationToken()\n" +
  "        ) {\n" +
  "            return await DbSet.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);\n" +
  "        }\n" +
  "\n" +
  "        public virtual TType GetById(TTypeId id) {\n" +
  "            var result = DbSet.Find(id);\n" +
  "            if (result.IsDeleted) {\n" +
  "                return null;\n" +
  "            }\n" +
  "\n" +
  "            return result;\n" +
  "        }\n" +
  "\n" +
  "        public virtual async Task<TType> GetByIdAsync(\n" +
  "            TTypeId id,\n" +
  "            CancellationToken cancellationToken = new CancellationToken()\n" +
  "        ) {\n" +
  "            var result = await DbSet.FindAsync(id, cancellationToken);\n" +
  "            if (result.IsDeleted) {\n" +
  "                return null;\n" +
  "            }\n" +
  "\n" +
  "            return result;\n" +
  "        }\n" +
  "\n" +
  "        public virtual bool Create(TType param) {\n" +
  "            DbSet.Add(param);\n" +
  "            return DataContext.SaveChanges() > 0;\n" +
  "        }\n" +
  "\n" +
  "        public virtual async Task<bool> CreateAsync(\n" +
  "            TType param,\n" +
  "            CancellationToken cancellationToken = new CancellationToken()\n" +
  "        ) {\n" +
  "            await DbSet.AddAsync(param, cancellationToken);\n" +
  "            return await DataContext.SaveChangesAsync(cancellationToken) > 0;\n" +
  "        }\n" +
  "\n" +
  "        public virtual bool Update(\n" +
  "            TType param) {\n" +
  "            DbSet.Update(param\n" +
  "            );\n" +
  "            return DataContext.SaveChanges() > 0;\n" +
  "        }\n" +
  "\n" +
  "        public virtual async Task<bool> UpdateAsync(\n" +
  "            TType param,\n" +
  "            CancellationToken cancellationToken = new CancellationToken()\n" +
  "        ) {\n" +
  "            DbSet.Update(param);\n" +
  "            return await DataContext.SaveChangesAsync(cancellationToken) > 0;\n" +
  "        }\n" +
  "\n" +
  "        public virtual void Delete(TType param) {\n" +
  "            if (param.IsDeleted) {\n" +
  "                return;\n" +
  "            }\n" +
  "\n" +
  "            param.IsDeleted = true;\n" +
  "            DbSet.Update(param);\n" +
  "        }\n" +
  "    }\n" +
  "}";