using DIP.lib.Services;

namespace DIP.lib.Managers.Base
{
    public class BaseManager
    {
        protected readonly MongoDbService Mongo;

        protected BaseManager(MongoDbService mongo)
        {
            Mongo = mongo;
        }
    }
}