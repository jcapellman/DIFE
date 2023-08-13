using DIP.API.Controllers.Base;
using DIP.lib.Objects.NonRelational;

using Microsoft.AspNetCore.Mvc;
using DIP.lib.Managers;
using DIFE.lib.Services.Base;

namespace DIP.API.Controllers
{
    public class DataSourceController : BaseController<DataSourceManager>
    {
        public DataSourceController(ILogger<DataSourceController> logger, BaseSourceService sService) : base(logger, sService)
        {
        }

        [HttpGet]
        public async Task<List<DataSources>> GetAsync() => await _manager.GetDataSourcesAsync();

        [HttpPost]
        public async Task<Guid> InsertAsync(DataSources dataSource) => await _manager.InsertDataSourceAsync(dataSource);

        [HttpDelete]
        public async Task<bool> DeleteAsync(Guid dataSourceId) => await _manager.DeleteDataSourceAsync(dataSourceId);

        [HttpPatch]
        public async Task<bool> UpdateAsync(DataSources dataSource) => await _manager.UpdateDataSourceAsync(dataSource);
    }
}