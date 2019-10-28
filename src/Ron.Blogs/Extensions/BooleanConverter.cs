using Newtonsoft.Json;
using System;

namespace Ron.Blogs.Extensions
{
    public class BooleanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool) || objectType == typeof(Nullable<bool>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            return Convert.ToBoolean(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else
            {
                UInt32 val = Convert.ToUInt32(Convert.ToBoolean(value));
                writer.WriteValue(val);
            }
        }
    }
}