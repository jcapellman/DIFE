using DIFE.lib.Enums;

namespace DIP.lib.Objects.Config
{
    public class InternalDataSourceConfig
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public InternalDataSourceType IDSType {  get; set; }

        public InternalDataSourceConfig()
        {
            ConnectionString = string.Empty;

            DatabaseName = string.Empty;
        }
    }
}