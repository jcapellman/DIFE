using DIP.lib.Services;
using DIP.lib.Managers.Base;
using Microsoft.AspNetCore.Mvc;

namespace DIP.API.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseManager
    {
        protected readonly ILogger<BaseController<T>> Logger;

        protected readonly T _manager;

        protected BaseController(ILogger<BaseController<T>> logger, MongoDbService mongo)
        {
            Logger = logger;

            _manager = Activator.CreateInstance(typeof(T), mongo) as T ?? throw new NullReferenceException(nameof(_manager));
        }
    }
}