namespace PCL.Presenter
{
    public class FriendVM
    {
        public string FirstLastName { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as FriendVM;

            if (item == null)
            {
                return false;
            }

            return FirstLastName.Equals(item.FirstLastName);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + FirstLastName.GetHashCode();
                hash = hash * 23 + FirstLastName.GetHashCode();
                return hash;
            }
        }
    }
}
