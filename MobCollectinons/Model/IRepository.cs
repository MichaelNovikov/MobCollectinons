using System.Collections.Generic;

namespace PCL
{
    public interface IRepository
    {
        List<Friend> GetListOfFriends();
    }
}
