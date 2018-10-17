using NUnit.Framework;
using PCL.Presenter;


namespace PCL_Tets
{
    [TestFixture]
    class FriendVM_ModelTest
    {
        FriendVM friend;

        [TestCase("Alex", "Alexeev")]
        [TestCase("Petr", "Petrov")]
        [TestCase(null, "Sergi")]
        [TestCase("Ivan", null)]
        public void CtorTest(string firstName, string lastName)
        {
            //When
            friend = new FriendVM() { FirstName = firstName, LastName = lastName };

            //Then
            Assert.AreEqual(firstName, friend.FirstName);
            Assert.AreEqual(lastName, friend.LastName);
        }
    }
}
