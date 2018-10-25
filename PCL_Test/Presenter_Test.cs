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
        public void GetFriendVM_OneItem_Test()
        {
            //Given
            var expect = new List<FriendVM> { new FriendVM { FirstLastName = "Ivan Ivanov" } };
            var mockRes = new List<Friend> { new Friend { FirstName = "Ivan", LastName = "Ivanov" } };

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            CollectionAssert.AreEqual(expect, actual);

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }

        [Test]
        public void GetFriendVM_TwoItems_Test()
        {
            //Given
            var expect = new List<FriendVM> { new FriendVM { FirstLastName = "Ivan Ivanov" }, new FriendVM { FirstLastName = "Petr Petrov" } };
            var mockRes = new List<Friend> { new Friend { FirstName = "Ivan", LastName = "Ivanov" }, new Friend { FirstName = "Petr", LastName = "Petrov" } };

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            CollectionAssert.AreEqual(expect, actual);

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }

        [Test]
        public void GetFriendVM_ManyItems_Test()
        {
            //Given
            var expect = new List<FriendVM> { new FriendVM { FirstLastName = "Ivan Ivanov" }, new FriendVM { FirstLastName = "Petr Petrov" },
                new FriendVM { FirstLastName = "Ivan Ivanov" }, new FriendVM { FirstLastName = "Jon Hu" }, new FriendVM { FirstLastName = "Alex Alexeev" },
                new FriendVM { FirstLastName = "Lisa Svon" }};

            var mockRes = new List<Friend> { new Friend { FirstName = "Ivan", LastName = "Ivanov" }, new Friend { FirstName = "Petr", LastName = "Petrov" },
                new Friend { FirstName = "Ivan", LastName = "Ivanov" }, new Friend { FirstName = "Jon", LastName = "Hu" }, new Friend { FirstName = "Alex", LastName = "Alexeev" },
                new Friend { FirstName = "Lisa", LastName = "Svon" } };

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            CollectionAssert.AreEqual(expect, actual);

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }

        [Test]
        public void GetFriendVM_ListOfFriednsNull_Test()
        {
            //Given
            var expect = new List<FriendVM>();
            List<Friend> mockRes = null;

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            CollectionAssert.AreEqual(expect, actual);

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }

        [Test]
        public void GetFriendVM_ListOfFriednsEmpty_Test()
        {
            //Given
            var expect = new List<FriendVM>();
            List<Friend> mockRes = new List<Friend>();

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            CollectionAssert.AreEqual(expect, actual);

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }

        [Test]
        public void GetFriendVM_ListOfFriednsItemNull_Test()
        {
            //Given
            var expect = new List<FriendVM>() { new FriendVM { FirstLastName = " " } };
            List<Friend> mockRes = new List<Friend>() { null };

            _repositoryMock.Setup(r => r.GetListOfFriends()).Returns(mockRes);

            //When
            var actual = _presenter.GetFriendVM();

            //Then
            CollectionAssert.AreEqual(expect, actual);

            _repositoryMock.Verify(r => r.GetListOfFriends(), Times.Once);
        }
    }
}
