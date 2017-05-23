using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApplication5
{
    public partial class Country : Form
    {   static CreateList List=new CreateList();
        static CountryDataBase DataBase = new CountryDataBase();
        public static Korzina Korzina = new Korzina();
        public static CreateTransport Transport = new CreateTransport();
        static Seria Seria = new Seria();
        static int idCity;
        static int sum=0;
        static int IndexName;
        static int idCountry;
        static bool a = true;
        static bool b = true;

        public Country(int i1,int i,int iname,Korzina m,CountryDataBase P1)
        {
            idCountry = i1;
            DataBase = P1;
            Korzina = m;
            IndexName = iname;
            idCity = i;              
            InitializeComponent();
        }

        private void Country_Load(object sender, EventArgs e)
        {
            a = true;
            b = true;  
            Dictionary<int, RadioButton> radioButton = new Dictionary<int, RadioButton>();
            Dictionary<int, RichTextBox> richTextBox = new Dictionary<int, RichTextBox>();
            int x2 = 10;
            int y2 = 20;
            int x3 = 10;
            int y3 = 60;
            for (int i = 0; i < DataBase.Mass[idCountry].City[idCity].Hotel.Count; i++)
            {
              
                radioButton[i] = new RadioButton();
                radioButton[i].AutoSize = true;
                radioButton[i].Text = DataBase.Mass[idCountry].City[idCity].Hotel[i].Name;
                radioButton[i].Cursor = Cursors.Hand;
                radioButton[i].Location = new Point(x2, y2);
                richTextBox[i] = new RichTextBox();
                richTextBox[i].Text = DataBase.Mass[idCountry].City[idCity].Hotel[i].Describe;
                richTextBox[i].ReadOnly = true;
                richTextBox[i].Font = new Font(Font, FontStyle.Regular);
                richTextBox[i].Size = new Size(250, 100);
                richTextBox[i].Location = new Point(x3, y3);
                panel1.Controls.Add(radioButton[i]);
                panel1.Controls.Add(richTextBox[i]);
                y2 += 150;
                y3 += 150;
            }
            Korzina=Seria.In(@"2.xml", Korzina);
        }
        private void Country_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sum = 0;


            for (int j = 0; j < panel1.Controls.Count; j++)
            {
                if (j % 2 == 0)
                {
                    if (((RadioButton)panel1.Controls[j]).Checked == true)
                    {
                        sum = sum + DataBase.Mass[idCountry].City[idCity].Hotel[j/2].Cost;
                        a = false;
                    }

                }
                
            }
            for (int j = 0; j < panel2.Controls.Count; j++)
            {
               
                    if (((RadioButton)panel2.Controls[j]).Checked == true)
                    {
                        sum = sum + Transport.Machine[j].Cost;
                        b = false;
                    }
               
            }
          
          
            if (a && b)
            {
                MessageBox.Show("Вы ничего не выбрали");
            }
            else if (a)
            {
                MessageBox.Show("Выберите отель");
            }
            else if(b)
            {
                MessageBox.Show("Выберите транспорт");
            }
           
            else
            {
                  label1.Text = "Цена:" + " " + Convert.ToString(sum) + " $";
            }
          
        
        }

        private void Back(object sender, EventArgs e)
        {
            var c = new Main(IndexName);
            this.Hide();
            c.Show();
        }

        private void Internet(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.booking.com");
        }

        private void AddToKorzina(object sender, EventArgs e)
        {
            sum = 0;
            for (int j = 0; j < panel1.Controls.Count; j++)
            {
                if (j % 2 == 0)
                {
                    if (((RadioButton)panel1.Controls[j]).Checked == true)
                    {
                        sum = sum + DataBase.Mass[idCountry].City[idCity].Hotel[j/2].Cost;
                        a = false;
                    }
                }
            }
            for (int j = 0; j < panel2.Controls.Count; j++)
            {

                if (((RadioButton)panel2.Controls[j]).Checked == true)
                {
                    sum = sum + Transport.Machine[j].Cost;
                    b = false;
                }

            }
            if (a && b)
            {
                MessageBox.Show("Вы ничего не выбрали");
            }
            else if (a)
            {
                MessageBox.Show("Выберите отель");
            }
            else if (b)
            {
                MessageBox.Show("Выберите транспорт");
            }
            else if (label1.Text == "")
            {
                MessageBox.Show("Вы не посчитали стоимость");
            }
            else
            {
                label1.Text ="Цена:"+" "+ Convert.ToString(sum)+" $";
                Korzina.Cost.Add(sum);
                for (int j = 0; j < panel1.Controls.Count; j++)
                {
                    if (j % 2 == 0)
                    {
                        if (((RadioButton)panel1.Controls[j]).Checked == true)
                        {
                            Korzina.Hotel.Add(DataBase.Mass[idCountry].City[idCity].Hotel[j/2].Name);
           
                        }
                    }
                }
                Korzina.Index.Add(IndexName);
               Seria.Out(@"2.xml", Korzina);
            }
           
        }
    }
}
