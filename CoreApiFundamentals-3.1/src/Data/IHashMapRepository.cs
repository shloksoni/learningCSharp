using CoreCodeCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data.Migrations
{
    public interface IHashMapRepository
    {
       string GetValue(string key);
        string AddKey(string key, string value);
        Boolean ContainsKey(string key);
        string DeleteKey(string key);
    }
}
