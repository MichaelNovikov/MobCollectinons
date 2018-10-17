
using System.IO;
using System.Reflection;

namespace PCL
{
    public class JsonGetter : IJsonGetter
    {
        public string GetJsonStr(string path)
        {
            string str;

            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(path))
            using (StreamReader sr = new StreamReader(stream))
            {
                str = sr.ReadToEnd();
            }
            return str;
        }
    }
}
