using Newtonsoft.Json;

namespace PCL
{
    public class Friend
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Friend;

            if (item == null)
            {
                return false;
            }

            return FirstName.Equals(item.FirstName) && LastName.Equals(item.LastName);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + FirstName.GetHashCode();
                hash = hash * 23 + LastName.GetHashCode();
                return hash;
            }
        }
    }
}
