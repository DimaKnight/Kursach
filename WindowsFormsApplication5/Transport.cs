using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    public class Transport
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Transport(string Name,int Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }
    }
    public class CreateTransport
    {
        public CreateTransport()
            {
            Machine = new Transport[]
            {
                 new Transport("Машина",200),
                 new Transport("Самолет",300),
                 new Transport("Поезд",100)
            };
            }
        public Transport[] Machine { get; set; }
    }
}
