using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication5
{
     public class Seria
    {
        public List<Massive> In(string way, List<Massive> p)
        {
            FileStream file1 = new FileStream(way, FileMode.Open);
            XmlSerializer filename1 = new XmlSerializer(typeof(List<Massive>));
            p = (List<Massive>)filename1.Deserialize(file1);
            file1.Close();
            return p;
        }
        public Korzina In(string way, Korzina p)
        {
            FileStream file1 = new FileStream(way, FileMode.Open);
            XmlSerializer filename1 = new XmlSerializer(typeof(Korzina));
            p = (Korzina)filename1.Deserialize(file1);
           
            file1.Close();
            return p;
        }

        public CreateList In(string way, CreateList p)
        {
            FileStream file1 = new FileStream(way, FileMode.Open);
            XmlSerializer filename1 = new XmlSerializer(typeof(CreateList));
            p = (CreateList)filename1.Deserialize(file1);
            file1.Close();
            return p;
        }
        public List<Curorts> In(string way, List<Curorts> p)
        {
            FileStream file1 = new FileStream(way, FileMode.Open);
            XmlSerializer filename1 = new XmlSerializer(typeof(List<Curorts>));
            p = (List <Curorts> )filename1.Deserialize(file1);
            file1.Close();
            return p;
        }
        public void Out(string way,Korzina p)
        {
            FileStream file = new FileStream(way, FileMode.Create);
            XmlSerializer fileName = new XmlSerializer(typeof(Korzina));
            fileName.Serialize(file, p);
            file.Close();
        }
        public void Out(string way, CreateList p)
        {
            FileStream file = new FileStream(way, FileMode.Create);
            XmlSerializer fileName = new XmlSerializer(typeof(CreateList));
            fileName.Serialize(file, p);
            file.Close();
        }

        public void Out(string way, List<Massive> p)
        {
            FileStream file = new FileStream(way, FileMode.Create);
            XmlSerializer fileName = new XmlSerializer(typeof(List<Massive>));
            fileName.Serialize(file, p);
            file.Close();
        }

        public void Out(string way,  List<Curorts> p)
        {
            FileStream file = new FileStream(way, FileMode.Create);
            XmlSerializer fileName = new XmlSerializer(typeof(List<Curorts>));
            fileName.Serialize(file, p);
            file.Close();
        }
    }
}
