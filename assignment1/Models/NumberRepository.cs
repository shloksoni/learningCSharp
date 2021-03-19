using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment1.Models
{
    public class NumberRepository : INumberRepository
    {
        public Number GenerateCorrectAns()
        {
            string now = (DateTime.Now).ToString();
            now = now.Substring(0, 2) + now.Substring(11, 2);
            
            return new Number
            {
                CorrectAns = now

            };

        }
    }
}
