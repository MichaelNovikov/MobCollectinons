using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace PCL
{
    public class Repository : IRepository
    {
        private IJsonGetter _jsonGetter;
        private List<Friend> _friends;
        private string _path = @"PCL.jsonFile.json";

        public Repository(IJsonGetter jsonGetter, string path)
            : this(jsonGetter)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public Repository(IJsonGetter jsonGetter)
        {
            _jsonGetter = jsonGetter ?? throw new ArgumentNullException(nameof(jsonGetter));
        }

        public List<Friend> GetListOfFriends()
        {
            if (_friends == null)
            {
                string jsonStr = _jsonGetter?.GetJsonStr(_path);
                _friends = JsonConvert.DeserializeObject<List<Friend>>(jsonStr);
            }
            return _friends;
        }
    }
}
