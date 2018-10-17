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
        public void Ctor_Test()
        {
            //When
            var fieldInfo1 = typeof(Repository)
                .GetField("_jsonGetter", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual1 = fieldInfo1.GetValue(_repository);

            var fieldInfo2 = typeof(Repository)
                .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual2 = fieldInfo2.GetValue(_repository);

            //Then
            Assert.AreEqual(_jsonGetterMock.Object, actual1);
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
            List<Friend> expectList = new List<Friend> { new Friend() { FirstName = "Ivan", LastName = "Ivanov" } };

            var mockStrRes = "[\r\n  {\r\n    \"firstname\": \"Ivan\",\r\n    \"lastname\": \"Ivanov\"\r\n  }\r\n]";

            _jsonGetterMock.Setup(j => j.GetJsonStr(It.IsAny<string>())).Returns(mockStrRes);

            var actualList = _repository.GetListOfFriends();

            Assert.AreEqual(expectList[0].FirstName, actualList[0].FirstName);
            Assert.AreEqual(expectList[0].LastName, actualList[0].LastName);

            _jsonGetterMock.Verify(g => g.GetJsonStr(It.IsAny<string>()), Times.Once);
        }
    }
}
