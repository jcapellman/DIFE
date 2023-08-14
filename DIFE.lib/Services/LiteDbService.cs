using DIFE.lib.Enums;
using DIFE.lib.Services.Base;
using DIP.lib.Objects.Config;
using LiteDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DIFE.lib.Services
{
    public class LiteDbService : BaseSourceService
    {
        public override InternalDataSourceType SourceType => InternalDataSourceType.LiteDb;

        private readonly InternalDataSourceConfig _config;

        public LiteDbService(InternalDataSourceConfig configuration)
        {
            _config = configuration;
        }

        public override Task<bool> DeleteAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<T>> GetManyAsync<T>(Expression<Func<T, bool>> expression)
        {
            using var db = new LiteDatabase(_config.ConnectionString);

            var col = db.GetCollection<T>();

            return col.Find(expression).ToList();
        }

        public override async Task<T> GetOneAsync<T>(Expression<Func<T, bool>> expression)
        {
            using var db = new LiteDatabase(_config.ConnectionString);

            var col = db.GetCollection<T>();

            return col.FindOne(expression);
        }

        public override async Task<Guid> InsertAsync<T>(T obj)
        {
            using var db = new LiteDatabase(_config.ConnectionString);

            var col = db.GetCollection<T>();

            var val = col.Insert(obj);

            return val.AsGuid;
        }

        public override async Task<bool> UpdateAsync<T>(T obj)
        {
            using var db = new LiteDatabase(_config.ConnectionString);

            var col = db.GetCollection<T>();

            return col.Update(obj);
        }
    }
}
