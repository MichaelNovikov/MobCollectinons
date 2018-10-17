using NUnit.Framework;
using PCL;


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

            var expect = "[\r\n  {\r\n    \"firstname\": \"Ivan\",\r\n    \"lastname\": \"Ivanov\"\r\n  }\r\n]";

            var actual = _jsonGetter.GetJsonStr(@"PCL.jsonSmall.json");

            Assert.AreEqual(expect, actual);
        }
    }
}
