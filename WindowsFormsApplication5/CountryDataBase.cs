using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{   [Serializable]
    public class CountryDataBase
    {
        
        public CountryDataBase()
        {
            Mass = new List<Massive>
             {
                 //1 страна
                  new Massive ("Ukraine",
                                     new List<City> { new City
                                     ( "Kiev",
                                        new List<Hotel> {
                                        new Hotel("Арт-отель Баккара",100,"Условия проживания"),
                                        new Hotel("Евроотель", 150,"Условия проживания") }
                                        )
                                     }
                                     )                        
             };
        }

        public List<Massive> Mass { get; set; }
    }
    [Serializable]
    public class Hotel
    {
        public Hotel(string name,int cost,string describe)
        {
            Name = name;
            Describe = describe;
            Cost = cost;
        }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Describe { get; set; }
        public Hotel()
        {

        }
    }
    [Serializable]
    public class City
    {
        public City()
            {

            }
        public City(string name, List<Hotel> hotel)
        {
            Name = name;
            Hotel = hotel;
        }
        public string Name { get; set; }
        public List<Hotel> Hotel { get; set; }
    }
}
