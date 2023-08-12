using DIP.lib.Enums;
using DIP.lib.Objects.NonRelational.Base;

namespace DIP.lib.Objects.NonRelational
{
    public class DataSources : BaseNonRelational
    {
        public required string Name { get; set; }

        public required string URI { get; set; }

        public required uint IntervalSeconds { get; set; }

        public required DataSourceType SourceType { get; set; }

        public DataSources()
        {
        }
    }
}