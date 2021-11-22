using System.Text.Json;

namespace LuPerfect.Serialization.Options
{
    public interface IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; }
    }
}
