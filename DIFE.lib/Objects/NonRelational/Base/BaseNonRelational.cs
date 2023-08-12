using MongoDB.Bson.Serialization.Attributes;

namespace DIP.lib.Objects.NonRelational.Base
{
    public class BaseNonRelational
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool Active { get; set; }
    }
}