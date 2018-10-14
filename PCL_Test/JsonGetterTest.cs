using NUnit.Framework;
using PCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_Test
{
    [TestFixture]
    class JsonGetterTest
    {
        JsonGetter _jsonGetter;

        [Test]
        public void GetJsonStr_Test()
        {
            _jsonGetter = new JsonGetter();

            var expect = "[{\"firstname\": \"Ivan\"," +
                "\"lastname\": \"Ivanov\"},{\"firstname\": \"Petr\",\"lastname\": \"Petrov\"}]";

            var actual = _jsonGetter.GetJsonStr("PCL.jsonSmall.json");

            Assert.AreEqual(expect, actual);
        }
    }
}
