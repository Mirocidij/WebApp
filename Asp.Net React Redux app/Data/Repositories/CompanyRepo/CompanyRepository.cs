using Asp.Net_React_Redux_app.Data.Repositories.Base;
using Asp.Net_React_Redux_app.Models;

namespace Asp.Net_React_Redux_app.Data.Repositories.CompanyRepo {
    public class CompanyRepository : BaseRepository<Company, long, DataContext>, ICompanyRepository {
        public CompanyRepository(DataContext dataContext) : base(dataContext) { }
    }
}