using DIP.lib.Managers.Base;
using Microsoft.AspNetCore.Mvc;
using DIFE.lib.Services.Base;

namespace DIP.API.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseManager
    {
        protected readonly ILogger<BaseController<T>> Logger;

        protected readonly T _manager;

        protected BaseController(ILogger<BaseController<T>> logger, BaseSourceService sService)
        {
            Logger = logger;

            _manager = Activator.CreateInstance(typeof(T), sService) as T ?? throw new NullReferenceException(nameof(_manager));
        }
    }
}