using DIP.lib.Objects.Config;
using DIP.lib.Objects.NonRelational.Base;
using DIP.lib.Objects.NonRelational;
using MongoDB.Driver;
using System.Linq.Expressions;
using DIFE.lib.Services.Base;
using DIFE.lib.Enums;

namespace DIP.lib.Services
{
    public class MongoDbService : BaseSourceService
    {
        private readonly IMongoDatabase _mongoDbClient;

        public override InternalDataSourceType SourceType => InternalDataSourceType.MongoDb;

        public MongoDbService(InternalDataSourceConfig configuration)
        {
            _mongoDbClient = new MongoClient(configuration.ConnectionString).GetDatabase(configuration.DatabaseName);
        }

        private IMongoCollection<T> Collections<T>()
        {
            var collection = typeof(T).Name;

            if (_mongoDbClient.ListCollectionNames().ToEnumerable().All(c => c != collection))
            {
                _mongoDbClient.CreateCollection(collection);
            }

            return _mongoDbClient.GetCollection<T>(collection);
        }

        public override async Task<bool> DeleteAsync<T>(Guid id)
        {
            var result = await Collections<T>().DeleteOneAsync<T>(a => a.Id == id);

            return result.DeletedCount > 0;
        }

        public override async Task<Guid> InsertAsync<T>(T obj)
        {
            await Collections<T>().InsertOneAsync(obj);

            return obj.Id;
        }

        public override async Task<List<T>> GetManyAsync<T>(Expression<Func<T, bool>> expression) =>
            await (await Collections<T>().FindAsync(expression)).ToListAsync();

        public async Task<Guid> InsertDataSource(DataSources dataSource)
        {
            await Collections<DataSources>().InsertOneAsync(dataSource);

            return dataSource.Id;
        }

        public override async Task<T> GetOneAsync<T>(Expression<Func<T, bool>> expression)
        {
            return await (await Collections<T>().FindAsync(expression)).FirstOrDefaultAsync();
        }

        public override async Task<bool> UpdateAsync<T>(T obj)
        {
            var result = await Collections<T>().ReplaceOneAsync<T>(a => a.Id == obj.Id, obj);

            return result.ModifiedCount > 0;
        }
    }
}