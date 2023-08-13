using DIFE.lib.Services.Base;
using DIP.lib.Managers.Base;
using DIP.lib.Objects.NonRelational;

namespace DIP.lib.Managers
{
    public class DataSourceManager : BaseManager
    {
        public DataSourceManager(BaseSourceService sService) : base(sService)
        {
        }

        public async Task<List<DataSources>> GetDataSourcesAsync() => await SourceService.GetManyAsync<DataSources>(a => a.Active);

        public async Task<Guid> InsertDataSourceAsync(DataSources dataSource) => await SourceService.InsertAsync(dataSource);

        public async Task<bool> DeleteDataSourceAsync(Guid id) => await SourceService.DeleteAsync<DataSources>(id);

        public async Task<bool> UpdateDataSourceAsync(DataSources dataSource) => await SourceService.UpdateAsync(dataSource);
    }
}