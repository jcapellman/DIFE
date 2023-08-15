using DIFE.lib.Enums;
using DIP.lib.Objects.Config;
using DIP.lib.Objects.NonRelational.Base;

using System.Linq.Expressions;

namespace DIFE.lib.Services.Base
{
    public abstract class BaseSourceService
    {
        public abstract InternalDataSourceType SourceType { get; }

        protected readonly InternalDataSourceConfig Configuration;

        protected BaseSourceService(InternalDataSourceConfig configuration)
        {
            Configuration = configuration;
        }

        public abstract Task<bool> UpdateAsync<T>(T obj) where T : BaseNonRelational;

        public abstract Task<T> GetOneAsync<T>(Expression<Func<T, bool>> expression) where T : BaseNonRelational;

        public abstract Task<bool> DeleteAsync<T>(Guid id) where T : BaseNonRelational;

        public abstract Task<Guid> InsertAsync<T>(T obj) where T : BaseNonRelational;

        public abstract Task<List<T>> GetManyAsync<T>(Expression<Func<T, bool>> expression) where T : BaseNonRelational;
    }
}