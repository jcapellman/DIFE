using DIFE.lib.Services.Base;

namespace DIP.lib.Managers.Base
{
    public class BaseManager
    {
        protected readonly BaseSourceService SourceService;

        protected BaseManager(BaseSourceService sService)
        {
            SourceService = sService;
        }
    }
}