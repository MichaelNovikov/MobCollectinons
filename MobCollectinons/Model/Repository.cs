using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PCL
{
    public class Repository : IRepository
    {
        private List<Friend> _friends;

        private string _path = @"PCL.jsonFile.json";

        public Repository()
        {

        }

        public Repository(string path)
        {
            _path = path;
        }

        private string GetJsonStr()
        {
            string str;

            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(_path))
            using (StreamReader sr = new StreamReader(stream))
            {
                str = sr.ReadToEnd();
            }
            return str;
        }

        public List<Friend> GetListOfFriends()
        {
            if (_friends == null)
            {
                string jsonStr = GetJsonStr();
                _friends = JsonConvert.DeserializeObject<List<Friend>>(jsonStr);
            }
            return _friends;
        }
    }
}
