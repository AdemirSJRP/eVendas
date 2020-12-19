using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Utils
{
    public static class Utils
    {
        private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None,
            Converters = new JsonConverter[] { new StringEnumConverter() }
        };

        public static string ToJsonString(this object source)
        {
            if (source == null) return null;
            return JsonConvert.SerializeObject(source, Formatting.Indented, JsonSettings);
        }

        public static byte[] ToBytes(this string source)
        {
            return Utf8NoBom.GetBytes(source);
        }

        public static byte[] ToJsonBytes(this object source)
        {
            return source.ToJsonString().ToBytes();
        }
    }
}
