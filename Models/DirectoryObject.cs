using Newtonsoft.Json;

namespace Example.Models
{
    public class DirectoryObject
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }

    }
}