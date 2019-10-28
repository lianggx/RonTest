﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Ron.Blogs.Extensions
{
    public class DateTimeConverter : DateTimeConverterBase
    {
        public static DateTime Greenwich_Mean_Time = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(Nullable<DateTime>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            if (CanConvert(objectType))
            {
                if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
                    return reader.Value;

                if (reader.Value is string || reader.TokenType == JsonToken.Date)
                {
                    if (DateTime.TryParse(reader.Value.ToString(), out DateTime dt))
                        return dt;
                    else
                        return reader.Value;
                }
                else
                    return new DateTime(Greenwich_Mean_Time.Ticks + Convert.ToInt64(reader.Value) * 10000).ToLocalTime();
            }
            else
                return reader.Value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else
            {
                long val = 0;
                if (value.GetType() == typeof(DateTime))
                {
                    DateTime dt = Convert.ToDateTime(value);
                    val = (dt.ToUniversalTime().Ticks - Greenwich_Mean_Time.Ticks) / 10000;
                }
                else
                    val = Convert.ToInt64(value);

                writer.WriteValue(val);
            }
        }
    }
}
