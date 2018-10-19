using Moq;
using NUnit.Framework;
using PCL;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PCL_Tets
{
    [TestFixture]
    class RepositoryTest
    {
        private Repository _repository;
        private Mock<IJsonGetter> _jsonGetterMock;

        [SetUp]
        public void SetUp()
        {
            _jsonGetterMock = new Mock<IJsonGetter>();
            _repository = new Repository(_jsonGetterMock.Object, "testStr");
        }

        [Test]
        public void CtorParamOne_Test()
        {
            //When
            var fieldInfo1 = typeof(Repository)
                .GetField("_jsonGetter", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual1 = fieldInfo1.GetValue(_repository);

            //Then
            Assert.AreEqual(_jsonGetterMock.Object, actual1);
        }

        [Test]
        public void CtorParamTwo_Test()
        {
            //When
            var fieldInfo2 = typeof(Repository)
                .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual2 = fieldInfo2.GetValue(_repository);

            //Then
            Assert.AreEqual("testStr", actual2);
        }

        [Test]
        public void CtorNull_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Repository(null, null));
        }

        [Test]
        public void GetListOfFriends_Test()
        {
            List<Friend> expectedList = new List<Friend> { new Friend() { FirstName = "Ivan", LastName = "Ivanov" } };

            var mockStrRes = "[\r\n  {\r\n    \"firstname\": \"Ivan\",\r\n    \"lastname\": \"Ivanov\"\r\n  }\r\n]";

            var fieldInfo2 = typeof(Repository)
            .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo2.SetValue(_repository, @"PCL.jsonFile.json");

            _jsonGetterMock.Setup(j => j.GetJsonStr(@"PCL.jsonFile.json")).Returns(mockStrRes);

            var actualList = _repository.GetListOfFriends();

            CollectionAssert.AreEqual(expectedList, actualList);

            _jsonGetterMock.Verify(g => g.GetJsonStr(@"PCL.jsonFile.json"), Times.Once);
        }

        [Test]
        public void GetListOfFriends_ifListNotNull_Test()
        {
            List<Friend> list = new List<Friend> { new Friend() { FirstName = "Ivan", LastName = "Ivanov" } };

            var mockStrRes = "[\r\n  {\r\n    \"firstname\": \"Ivan\",\r\n    \"lastname\": \"Ivanov\"\r\n  }\r\n]";

            var field_friends = typeof(Repository)
            .GetField("_friends", BindingFlags.NonPublic | BindingFlags.Instance);
            field_friends.SetValue(_repository, list);

            _jsonGetterMock.Setup(j => j.GetJsonStr(@"PCL.jsonFile.json")).Returns(mockStrRes);

            var actualList = _repository.GetListOfFriends();

            _jsonGetterMock.Verify(g => g.GetJsonStr(@"PCL.jsonFile.json"), Times.Never);
        }

        [Test]
        public void GetListOfFriends_ifJsonStrNull_Test()
        {
            List<Friend> listExpect = new List<Friend> {};

            string mockStrRes = null;

            var field_friends = typeof(Repository)
            .GetField("_friends", BindingFlags.NonPublic | BindingFlags.Instance);
            field_friends.SetValue(_repository, listExpect);

            _jsonGetterMock.Setup(j => j.GetJsonStr(@"PCL.jsonFile.json")).Returns(mockStrRes);

            var actualList = _repository.GetListOfFriends();

            Assert.AreEqual(listExpect, actualList);

            _jsonGetterMock.Verify(g => g.GetJsonStr(@"PCL.jsonFile.json"), Times.Once);
        }
    }
}
