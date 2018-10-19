using Moq;
using NUnit.Framework;
using PCL;
using PCL.Presenter;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PCL_Test
{
    [TestFixture]
    class Presenter_Test
    {
        private Presenter _presenter;
        private Mock<IRepository> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository>();
            _presenter = new Presenter(_repositoryMock.Object);
        }

        [Test]
        public void Ctor_Test()
        {
            //Given
            var fieldInfo = typeof(Presenter)
                .GetField("_repository", BindingFlags.NonPublic | BindingFlags.Instance);

            //When
            var actual = fieldInfo.GetValue(_presenter);

            //Then
            Assert.AreEqual(_repositoryMock.Object, actual);
        }
    
        [Test]
        public void CtrorNull_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Presenter(null));
        }

        [Test]
        public void GetFriendVM_Test()
        {
            //Given
            var expect = new List<FriendVM> { new FriendVM { FirstLastName = "Ivan Ivanov" } };        
            var mockRes = new List<Friend> { new Friend{ FirstName = "Ivan", LastName = "Ivanov" } };

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            Assert.AreEqual(expect[0].ToString(), actual[0].ToString());

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }
    }
}
