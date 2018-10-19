using NUnit.Framework;
using PCL.Presenter;


namespace PCL_Tets
{
    [TestFixture]
    class FriendVM_ModelTest
    {
        FriendVM friend;

        [TestCase("Alex Alexeev")]
        [TestCase("Petr Petrov")]

        public void CtorTest(string firstLastName)
        {
            //When
            friend = new FriendVM() {FirstLastName = firstLastName};

            //Then
            Assert.AreEqual(firstLastName, friend.FirstLastName);
        }
    }
}
