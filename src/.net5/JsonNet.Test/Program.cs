using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonNet.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <see cref="HandleJsonConverter"/>
            /// <see cref="MyClass"/>
            #region JsonConverter
            // FunJsonConverter();
            #endregion

            /// <see cref="DefaultValueHandlingTest"/>
            #region DefaultValueHandling
            FunDefaultValueHandling();
            #endregion
            Console.ReadLine();
        }
        #region 测试输出
        static void FunJsonConverter()
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
        }

        static void FunDefaultValueHandling()
        {
            var settingsDefaultValueHandling = new JsonSerializerSettings();
            var jsonDefaultValueHandlingDefault = JsonConvert.SerializeObject(new DefaultValueHandlingTest());
            Console.WriteLine("Default:{0}", jsonDefaultValueHandlingDefault);
            var jsonDefault = "{\"P1\":1,\"P3\":\"0001-01-01T00:00:00\"}";
            var jsonObjectDefault = JsonConvert.DeserializeObject<DefaultValueHandlingTest>(jsonDefault);
            Console.WriteLine("Default:{0}", jsonObjectDefault.ToString());

            settingsDefaultValueHandling.DefaultValueHandling = DefaultValueHandling.Include;
            var jsonDefaultValueHandlingInclude = JsonConvert.SerializeObject(new DefaultValueHandlingTest(), settingsDefaultValueHandling);
            Console.WriteLine("Include:{0}", jsonDefaultValueHandlingInclude);
            var jsonInclude = "{\"P1\":1,\"P3\":\"0001-01-01T00:00:00\"}";
            var jsonIncludeDefault = JsonConvert.DeserializeObject<DefaultValueHandlingTest>(jsonInclude);
            Console.WriteLine("Include:{0}", jsonIncludeDefault.ToString());

            settingsDefaultValueHandling.DefaultValueHandling = DefaultValueHandling.Ignore;
            var jsonDefaultValueHandlingIgnore = JsonConvert.SerializeObject(new DefaultValueHandlingTest() { P1=1}, settingsDefaultValueHandling);
            Console.WriteLine("Ignore:{0}", jsonDefaultValueHandlingIgnore);
            var jsonIgnore = "{\"P3\":\"0001-01-01T00:00:00\"}";
            var jsonObjectIgnore = JsonConvert.DeserializeObject<DefaultValueHandlingTest>(jsonIgnore);
            Console.WriteLine("Ignore:{0}", jsonObjectIgnore.ToString());

            settingsDefaultValueHandling.DefaultValueHandling = DefaultValueHandling.Populate;
            var jsonDefaultValueHandlingPopulate = JsonConvert.SerializeObject(new DefaultValueHandlingTest(), settingsDefaultValueHandling);
            Console.WriteLine("Populate:{0}", jsonDefaultValueHandlingPopulate);
            var jsonPopulate = "{\"P1\":1,\"P3\":\"0001-01-01T00:00:00\"}";
            var jsonObjectPopulate = JsonConvert.DeserializeObject<DefaultValueHandlingTest>(jsonPopulate);
            Console.WriteLine("Populate:{0}", jsonObjectPopulate.ToString());

            // 总结:
            // 1.当使用`DefaultValueHandling.Include`:包括成员值与序列化对象时成员的默认值相同的成员。包含的成员被写入JSON。反序列化时不起作用。
            // 2.Populate与IgnoreAndPopulate只能在JsonProperty上使用才有效,使用JsonSerializerSettings无效。     
            // 3.Ignore该选项将忽略所有默认值(例如，对象和可空类型为null;0表示整数、小数和浮点数;布尔值则为false)。忽略的默认值可以通过在属性上放置DefaultValueAttribute来更改。
        }
        #endregion

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

    #region DefaultValueHandling
    class DefaultValueHandlingTest
    {
        [DefaultValue(1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int P1 { get; set; }
        public int P1_1 { get; set; }

        [DefaultValue("我是P2")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string P2 { get; set; }
        public string P2_2 { get; set; }

        [DefaultValue(typeof(DateTime), "2021-03-12 22:00:00")]
        public DateTime P3 { get; set; }
        public DateTime P3_3 { get; set; }

        [DefaultValue(true)]
        public bool P4 { get; set; }
        public bool P4_4 { get; set; }

        public override string ToString()
        {
            return $"P1:{P1},P1_1:{P1_1};P2:{P2},P2_2:{P2_2};P3:{P3},P3_3:{P3_3}";
        }
    }
    #endregion
}
