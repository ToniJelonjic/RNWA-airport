using Newtonsoft.Json.Converters;

namespace REST_API.Helpers
{
    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
