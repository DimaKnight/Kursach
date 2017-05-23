using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    [Serializable]
    public class Massive
    {
        public Massive(string country,  List<City> city)
        {
            Country = country;
            City = city;
        }
        public Massive()
        {
            
        }

        public string data;
        public string Country { get; set; }
        public List<City> City { get; set; }
  
    }
}
