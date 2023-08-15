using DIFE.lib.Enums;
using DIFE.lib.Services.Base;
using DIP.lib.Objects.Config;
using LiteDB;
using LiteDB.Async;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DIFE.lib.Services
{
    public class LiteDbService : BaseSourceService
    {
        public override InternalDataSourceType SourceType => InternalDataSourceType.LiteDb;

        public LiteDbService(InternalDataSourceConfig configuration) : base(configuration)
        {
        }

        public override async Task<bool> DeleteAsync<T>(Guid id)
        {
            using var db = new LiteDatabaseAsync(Configuration.ConnectionString);

            var col = db.GetCollection<T>();

            return await col.DeleteAsync(id);
        }

        public override async Task<List<T>> GetManyAsync<T>(Expression<Func<T, bool>> expression)
        {
            using var db = new LiteDatabaseAsync(Configuration.ConnectionString);

            var col = db.GetCollection<T>();

            return (await col.FindAsync(expression)).ToList();
        }

        public override async Task<T> GetOneAsync<T>(Expression<Func<T, bool>> expression)
        {
            using var db = new LiteDatabaseAsync(Configuration.ConnectionString);

            var col = db.GetCollection<T>();

            return await col.FindOneAsync(expression);
        }

        public override async Task<Guid> InsertAsync<T>(T obj)
        {
            using var db = new LiteDatabaseAsync(Configuration.ConnectionString);

            var col = db.GetCollection<T>();

            var val = await col.InsertAsync(obj);

            return val.AsGuid;
        }

        public override async Task<bool> UpdateAsync<T>(T obj)
        {
            using var db = new LiteDatabaseAsync(Configuration.ConnectionString);

            var col = db.GetCollection<T>();

            return await col.UpdateAsync(obj);
        }
    }
}