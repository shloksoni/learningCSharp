using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Data.Migrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class HashMapRepository : IHashMapRepository
    {
        private HashMap hmap;
        public HashMapRepository()
        {
            hmap = new HashMap
            {
                dict = new Dictionary<string, string>()
            };

        }
        public string AddKey(string key, string value)
        {
            if (hmap.dict.ContainsKey(key)) hmap.dict[key] = value;
            else hmap.dict.Add(key, value);
            return value;
        }

   

        public string GetValue(string key)
        {
  
            return hmap.dict[key];
        }

        public Boolean ContainsKey(string key) => hmap.dict.ContainsKey(key);

        public string DeleteKey(string key)
        {

            hmap.dict.Remove(key);
            return "Removed";
        }
    }
}
