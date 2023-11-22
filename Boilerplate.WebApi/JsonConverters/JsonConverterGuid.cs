using Eshop.Application.Common.Constants.Common;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Eshop.WebApi.JsonConverters
{
    public class JsonConverterGuid : JsonConverter<Guid>
    {
        private readonly Regex _uwCharRegex = new Regex("[ :;\t-]");
        private readonly Regex _validityRegex = new Regex("[a-fA-F0-9]{32}");
        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var guid = reader.GetString();

            if (guid != string.Empty && guid != null)
            {
                var replacedGuid = _uwCharRegex.Replace(guid, "");

                if (_validityRegex.IsMatch(replacedGuid))
                {
                    return new Guid(replacedGuid);
                }
                else {
                    throw new NotImplementedException(CommonConstans.MODEL_ID_GUID_BAD_FORMAT);
                }
            }
            else
            {
                return Guid.Empty;
            }
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
