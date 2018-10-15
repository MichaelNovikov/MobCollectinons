using System;
using System.Collections.Generic;
using System.Text;

namespace PCL
{
    public interface IJsonGetter
    {
        string GetJsonStr(string path);
    }
}
