using Newtonsoft.Json;

namespace PCL
{
    public class Friend
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
}
