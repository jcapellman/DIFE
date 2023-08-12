using DIP.lib.Managers.Base;
using DIP.lib.Objects.NonRelational;
using DIP.lib.Services;

namespace DIP.lib.Managers
{
    public class DataSourceManager : BaseManager
    {
        public DataSourceManager(MongoDbService mongo) : base(mongo)
        {
        }

        public async Task<List<DataSources>> GetDataSourcesAsync() => await Mongo.GetManyAsync<DataSources>(a => a.Active);

        public async Task<Guid> InsertDataSourceAsync(DataSources dataSource) => await Mongo.InsertAsync(dataSource);

        public async Task<bool> DeleteDataSourceAsync(Guid id) => await Mongo.DeleteAsync<DataSources>(id);

        public async Task<bool> UpdateDataSourceAsync(DataSources dataSource) => await Mongo.UpdateAsync(dataSource);
    }
}