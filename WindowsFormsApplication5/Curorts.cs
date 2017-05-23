using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    public class Curorts
    {
        public Curorts(string curortname,List<string> city,int cost,string describe)
        {
            CurortName = curortname;
            City = city;
            Cost = cost;
            Describe = describe;
        }
        public string CurortName { get; set; }
        public List<string> City { get; set; }
        public int Cost { get; set; }
        public string Describe { get; set; }
        public Curorts()
        {

        }
    }
   
   
}
