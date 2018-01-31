using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static int Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("Hello World!");

            var person = new Person { FirstName = "Feodor", LastName = "Fitsner" };
            person.OtherProps["Key1"] = "Value1";
            person.OtherProps["Key2"] = "Value2";

            var json = ToJson(person);

            var json1 = "{\"firstName\":\"Feodor\",\"lastName\":\"Fitsner\"}";

            var p = FromJson<Person>(json);

            return 0; 
        }

        private static string ToJson<T>(T obj)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), GetJsonSettings());

            MemoryStream stream1 = new MemoryStream();
            ser.WriteObject(stream1, obj);

            return Encoding.UTF8.GetString(stream1.ToArray());
        }

        private static T FromJson<T>(string json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), GetJsonSettings());
            T deserializedUser = (T)ser.ReadObject(ms);
            ms.Close();
            return deserializedUser;
        }

        private static DataContractJsonSerializerSettings GetJsonSettings()
        {
            return new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            };
        }
    }
}
