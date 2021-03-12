using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonNet.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var oldJson = "{\"Test\":\"聊聊\"}";
            var newJson = "{\"Test\":{\"Key\":\"1\",\"Value\":\"Jonny\"}}";
            var old = JsonConvert.DeserializeObject<MyClass>(oldJson);
            var @new = JsonConvert.DeserializeObject<MyClass>(newJson);
            Console.WriteLine("Old {0}", old.Test.Value);
            Console.WriteLine("New {0}", @new.Test.Value);
            var newJson2 = JsonConvert.SerializeObject(new MyClass() { Test = new KeyValuePair<string, string>("2", "我又序列化了") });
            Console.WriteLine(newJson2);
            var @new2 = JsonConvert.DeserializeObject<MyClass>(newJson2);
            Console.WriteLine("New2 {0}", @new.Test.Value);
            Console.ReadLine();
        }
    }
    class MyClass
    {
        [JsonConverter(typeof(HandleJsonConverter))]
        public KeyValuePair<string, string> Test { get; set; }
    }
    class HandleJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KeyValuePair<string, string>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new KeyValuePair<string, string>("我从String转为KeyValuePair<>了", reader.Value?.ToString());
            }
            return JObject.Load(reader).ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var p = (KeyValuePair<string, string>)value;
            var j = new JObject();
            j["Key"] = p.Key;
            j["Value"] = p.Value;
            writer.WriteValue(j.ToString());
            //serializer.Serialize(writer, value, value.GetType());
        }
    }
}
