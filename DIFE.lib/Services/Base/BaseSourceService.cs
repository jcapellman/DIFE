using DIP.lib.Objects.NonRelational.Base;

namespace DIFE.lib.Services.Base
{
    public abstract class BaseSourceService
    {
        public abstract Task<bool> UpdateAsync<T>(T source) where T : BaseNonRelational;
    }
}