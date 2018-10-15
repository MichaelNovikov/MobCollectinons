using NUnit.Framework;
using PCL;

namespace PCL_Tets
{
    [TestFixture]
    public class FriendModelTest
    {
        Friend friend;

        [TestCase("Alex", "Alexeev")]
        [TestCase(null, "Sergi")]
        [TestCase("Ivan", null)]
        [TestCase("", "")]
        public void CtorTest(string firstName, string lastName)
        {
            //When
            friend = new Friend() { FirstName = firstName, LastName = lastName };

            //Then
            Assert.AreEqual(firstName, friend.FirstName);
            Assert.AreEqual(lastName, friend.LastName);
        }
    }
}
