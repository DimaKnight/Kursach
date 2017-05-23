using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication5
{
    [Serializable]
    public partial class AddCountry : Form
    {
        static CountryDataBase List = new CountryDataBase();
        static List<Massive> Mass = new List<Massive> { };
        static int sum=0;
        static int sum1 = 0;
        static int sum2 = 0;
        static int IndexName;
        static Seria Seria = new Seria();
        public AddCountry(int i)
        {
            IndexName = i;   
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List.Mass = Seria.In(@"3.xml",Mass );
        }
        private void Add(object sender, EventArgs e)
        {   
            try
            {
                
                sum = 0;
                sum1 = 0;
                sum2 = 0;
                for (int i = 0; i < List.Mass.Count(); i++) // 2 UKRAINE USA USA popas vasya
                {
                    if (textBox1.Text == List.Mass[i].Country)
                    { sum++;
                        for (int j = 0; j < List.Mass[i].City.Count(); j++)
                        {
                            if (textBox2.Text == List.Mass[i].City[j].Name) // Lviv Kiev Popas
                            {
                                sum1++;
                                for (int l = 0; l < List.Mass[i].City[j].Hotel.Count(); l++) //2 dima vasya popa
                                {
                                    if (textBox3.Text == List.Mass[i].City[j].Hotel[l].Name)
                                    {
                                        sum2++;
                                    }

                                }
                                if (sum2 == 0)
                                {
                                    List.Mass[i].City[j].Hotel.Add(new Hotel(textBox3.Text, Convert.ToInt32(textBox4.Text), richTextBox1.Text));
                                    Seria.Out(@"3.xml", List.Mass);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Такой Отель уже есть в данном городе");
                                    return;
                                }
                            }
                        }
                        if (sum1 == 0)
                        {
                            List.Mass[i].City.Add(new City(textBox2.Text, new List<Hotel>
                        {new Hotel(textBox3.Text, Convert.ToInt32(textBox4.Text),richTextBox1.Text) }));
                            Seria.Out(@"3.xml", List.Mass);
                            return;
                        }

                    }

                }
                if (sum == 0)
                {
                    List.Mass.Add(new Massive(textBox1.Text, new List<City> {new City(textBox2.Text,new List<Hotel>
            { new Hotel(textBox3.Text,Convert.ToInt32(textBox4.Text),richTextBox1.Text)} )}));
                    Seria.Out(@"3.xml", List.Mass);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Введите правильно информацию");
                return;
            }
           }


        private void Back(object sender, EventArgs e)
        {
            var form = new Main(IndexName);
            form.Show();
            this.Hide();         
        }

        private void AddCountry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
