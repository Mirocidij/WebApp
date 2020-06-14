using Asp.Net_React_Redux_app.Models;
using EasyRepository.Repositories;

namespace Asp.Net_React_Redux_app.Data.Repositories.CompanyRepo {
    public class CompanyRepository : BaseRepository<Company, long, DataContext>, ICompanyRepository {
        public CompanyRepository(DataContext dataContext) : base(dataContext) { }
    }
}