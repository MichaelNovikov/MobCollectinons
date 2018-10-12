using NUnit.Framework;
using PCL;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PCL_Tets
{
    [TestFixture]
    class RepositoryTest
    {
        private Repository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new Repository();
        }

        [Test]
        public void CtorTest()
        {
            _repository = new Repository("testStr");

            //When
            var fieldInfo = typeof(Repository)
                .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual = fieldInfo.GetValue(_repository);

            //Then
            Assert.AreEqual("testStr", actual);
        }

        [Test]
        public void GetJsonStr_Test()
        {
           var  methodInfo = typeof(Repository).GetMethod("GetJsonStr");
           var res = methodInfo.Invoke(_repository, new object[] { });

           Assert.AreEqual(typeof(string), res.GetType());
        }
    }
}
