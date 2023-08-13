using DIFE.lib.Services.Base;
using DIP.lib.Objects.NonRelational.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFE.lib.ServiceManager
{
    public class DataSourceServiceManager
    {
        private List<BaseSourceService> _dsServices = new List<BaseSourceService>();

        public async Task<bool> UpdateAsync<T>(T obj) where T : BaseNonRelational
        {
            return default;
        }
    }
}