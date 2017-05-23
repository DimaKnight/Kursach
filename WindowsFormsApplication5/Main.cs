using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApplication5
{
   
    public partial class Main : Form
    {
        static CountryDataBase DataBase = new CountryDataBase();
        //static List<Massive> p1 = new List<Massive> {};
        static int IndexName;
        static Korzina Korzina = new Korzina();
        static Seria Seria = new Seria();
        static CreateList List = new CreateList();

        public Main(int i)
        {
            IndexName = i;
            InitializeComponent();
        }

        public static Dictionary<int, Label> label = new Dictionary<int, Label>();
        public static Dictionary<int, Button> button = new Dictionary<int, Button>();
        public static Dictionary<int, DateTimePicker> Date = new Dictionary<int, DateTimePicker>();

        private void ChangeOfCountry(object sender, EventArgs e)
        {        
            CityBox.Items.Clear();
            CityBox.Text = "";           
            foreach (var item in DataBase.Mass)
            {
                if (CountryBox.Items[CountryBox.SelectedIndex].ToString() == item.Country)
                {
                    foreach (var item1 in item.City)
                    {
                        CityBox.Items.Add(item1.Name);
                    }
                }
               
            }          
        }

        private void Main_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            List = Seria.In(@"1.xml", List);
            //FileStream file1 = new FileStream(@"3.xml", FileMode.Create);
            //XmlSerializer fileName1 = new XmlSerializer(typeof(List<Massive>));
            //fileName1.Serialize(file1, p.Mass);
            //file1.Close();
            //Seria.Out(@"3.xml", DataBase.Mass);
            DataBase.Mass = Seria.In(@"3.xml", DataBase.Mass);
            panel1.Hide();
            KorzinaLabel.Hide();
            IElLabel.Hide();
            Counter.Hide();
            Delete.Hide();
            button3.Hide();
            dateTimePicker1.Hide();
            numericUpDown1.Hide();
            label3.Hide();
            int x2 = 10;
            int y2 = 20;
            int x3 = 200;
            int y3 = y2;
            int q = 0;
            int sum1 = 0;
            int sum2 = 0;              
            int i = 0;
            foreach (var item in DataBase.Mass)
            {
                CountryBox.Items.Add("");
                CountryBox.Items[i] =item.Country ;
                i++;
            }

            Korzina=Seria.In(@"2.xml", Korzina);
            int q1 = Korzina.Cost.Count();
            int q3 = q1 * 2 ;
            int q4 = Korzina.CostCur.Count() + q1 * 2;
            int q2 = Korzina.Cost.Count()*2 + Korzina.CostCur.Count()*2;
            Counter.Minimum = 1;
            numericUpDown1.Minimum = 1;
            for (int asd = 0; asd < Korzina.Index.Count; asd++)
            {
                if (Korzina.Index[asd] == IndexName)
                {
                    sum2++;
                }
            }
            Counter.Maximum = sum2;
            numericUpDown1.Maximum = sum2;

            for (int j = 0; j < Korzina.Hotel.Count(); j++,q++,q1++)
            {
                if (IndexName == Korzina.Index[j])
                {
                 
                       
                        label[q] = new Label();
                        label[q].AutoSize = true;
                        label[q].Text = Korzina.Hotel[j];
                        label[q].Location = new Point(x2, y2);
                        label[q1] = new Label();
                        label[q1].AutoSize = true;
                        label[q1].Text = Convert.ToString(Korzina.Cost[j]) + " $";
                        label[q1].Location = new Point(x3, y3);
                       
                        sum1 += Korzina.Cost[j];


                        panel1.Controls.Add(label[q]);
                        panel1.Controls.Add(label[q1]);
                       
                        y2 += 60;
                        y3 += 60;
                      
                                            
                }
            }
            int x6 = x2;
            int y6 = y3;
            label[q2] = new Label();
            label[q2].Text = Convert.ToString(sum1) + " $ Суммарная стоимость";
            label[q2].AutoSize = true;
            label[q2].Location = new Point(x6, y6);
            panel1.Controls.Add(label[q2]);
        }

        private void GoToForm(object sender, EventArgs e)
        {
            if (CountryBox.Text == "")
            {
                MessageBox.Show("Выберите страну");
                return;
            }
            if (CityBox.Text == "")
            {
                MessageBox.Show("Выберите город");
                return;
            }          
            Form c1 ;
            
            DataBase.Mass.Add(DataBase.Mass[CountryBox.SelectedIndex]);
            c1 = new Country(CountryBox.SelectedIndex,CityBox.SelectedIndex,IndexName,Korzina,DataBase);
            this.Hide();
            c1.Show();
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void GoToCurort(object sender, EventArgs e)
        {
            var c = new Curort(IndexName);
            this.Hide();
            c.Show();
        }

        private void DeleteBut(object sender, EventArgs e)
        {
            if(Counter.Value==0)
            {
                MessageBox.Show("Вам нечего удалять");
                return;
            }
            int x2 = 10;
            int y2 = 20;
            int x3 = 200;
            int y3 = y2;
           
            int q = 0;
            int sum1 = 0;
            int sum2 = 0;
            var x = new Main(IndexName);

            for (int i = 0; i < Korzina.Index.Count(); i++)
            {
                if (IndexName == Korzina.Index[i])
                {
                    Korzina.Cost.RemoveAt((int)Counter.Value - 1 + i);
                    Korzina.Hotel.RemoveAt((int)Counter.Value - 1 + i);
                    Korzina.Index.RemoveAt((int)Counter.Value - 1 + i);
                    break;
                }
            }
            Seria.Out(@"2.xml", Korzina);
            panel1.Controls.Clear();
            
            int q1 = Korzina.Cost.Count();
            int q3 = q1 * 2;
            int q4 = Korzina.CostCur.Count() + q1 * 2;
            int q2 = Korzina.Cost.Count() * 2 + Korzina.CostCur.Count() * 2;
            Counter.Minimum = 1;
            numericUpDown1.Minimum = 1;
            for (int asd = 0; asd < Korzina.Index.Count; asd++)
            {
                if (Korzina.Index[asd] == IndexName)
                {
                    sum2++;
                }
            }
            Counter.Maximum = sum2;
            numericUpDown1.Maximum = sum2;

            for (int j = 0; j < Korzina.Hotel.Count(); j++)
            {
                if (IndexName == Korzina.Index[j])
                {
                    label[q] = new Label();
                    label[q].AutoSize = true;
                    label[q].Text = Korzina.Hotel[j];
                    label[q].Location = new Point(x2, y2);
                    label[q1] = new Label();
                    label[q1].AutoSize = true;
                    label[q1].Text = Convert.ToString(Korzina.Cost[j]) + " $";
                    label[q1].Location = new Point(x3, y3);
                    sum1 += Korzina.Cost[j];
                    panel1.Controls.Add(label[q]);
                    panel1.Controls.Add(label[q1]);
                    y2 += 60;
                    y3 += 60;
                
                    q++;
                    q1++;
                    
               }
            }
            int x6 = x2;
            int y6 = y3;
            label[q2] = new Label();
            label[q2].Text = Convert.ToString(sum1) + " $ Суммарная стоимость";
            label[q2].AutoSize = true;
            label[q2].Location = new Point(x6, y6);
            panel1.Controls.Add(label[q2]);
        }

        private void ShowKorzinu(object sender, EventArgs e)
        {
            panel1.Show();
            KorzinaLabel.Show();
            IElLabel.Show();
            Counter.Show();
            Delete.Show();
            button3.Show();
            dateTimePicker1.Show();
            numericUpDown1.Show();
            label3.Show();
        }

        private void HideKorzinu(object sender, EventArgs e)
        {
            panel1.Hide();
            KorzinaLabel.Hide();
            IElLabel.Hide();  
            Counter.Hide();
            Delete.Hide();
            button3.Hide();
            dateTimePicker1.Hide();
            numericUpDown1.Hide();
            label3.Hide();
        }

        private void GoToAddForm(object sender, EventArgs e)
        {
            var c = new AddCountry(IndexName);
            this.Hide();
            c.Show();
        }

        private void BuyCheck(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < Korzina.Index.Count; i++)
            {
                if (Korzina.Index[i] == IndexName)
                {
                    sum++;
                }
            }
            if(sum==0)
            {
                MessageBox.Show("Вам нечего покупать");
                return;
            }
            if(dateTimePicker1.Value<DateTime.UtcNow.Date)
            {
                MessageBox.Show("Введите правильную дату");
                return;
            }
            StreamWriter file = File.CreateText("Ticket.txt");
            file.Write("Имя: "+""+List.ListName[IndexName]);
            file.WriteLine();
            file.Write("Время: " + "" + dateTimePicker1.Value.ToString());
            file.WriteLine();
            file.Write("Список покупок:");
            file.WriteLine();

            for (int i = 0, p = 0; i < Korzina.Index.Count(); i++)
            {
                if (IndexName == Korzina.Index[i])
                {
                    file.Write("Название: " + "" + Korzina.Hotel[(int)numericUpDown1.Value - 1+i]);
                    file.WriteLine();
                    file.Write("Стоимость поездки: " + "" + Korzina.Cost[(int)numericUpDown1.Value - 1+i] + "$");
                    file.WriteLine();
                    Korzina.Cost.RemoveAt((int)numericUpDown1.Value - 1 + i);
                    Korzina.Hotel.RemoveAt((int)numericUpDown1.Value - 1 + i);
                    Korzina.Index.RemoveAt((int)numericUpDown1.Value - 1 + i);

                    break;
                }
            }
            Seria.Out(@"2.xml", Korzina);
            panel1.Controls.Clear();
            int x2 = 10;
            int y2 = 20;
            int x3 = 200;
            int y3 = y2;

            int q = 0;
            int sum1 = 0;
            int sum2 = 0;
            int q1 = Korzina.Cost.Count();
            int q3 = q1 * 2;
            int q4 = Korzina.CostCur.Count() + q1 * 2;
            int q2 = Korzina.Cost.Count() * 2 + Korzina.CostCur.Count() * 2;
            Counter.Minimum = 1;
            numericUpDown1.Minimum = 1;
            for (int asd = 0; asd < Korzina.Index.Count; asd++)
            {
                if (Korzina.Index[asd] == IndexName)
                {
                    sum2++;
                }
            }
            Counter.Maximum = sum2;
            numericUpDown1.Maximum = sum2;

            for (int j = 0; j < Korzina.Hotel.Count(); j++)
            {
                if (IndexName == Korzina.Index[j])
                {
                    label[q] = new Label();
                    label[q].AutoSize = true;
                    label[q].Text = Korzina.Hotel[j];
                    label[q].Location = new Point(x2, y2);
                    label[q1] = new Label();
                    label[q1].AutoSize = true;
                    label[q1].Text = Convert.ToString(Korzina.Cost[j]) + " $";
                    label[q1].Location = new Point(x3, y3);
                    sum1 += Korzina.Cost[j];
                    panel1.Controls.Add(label[q]);
                    panel1.Controls.Add(label[q1]);
                    y2 += 60;
                    y3 += 60;

                    q++;
                    q1++;

                }
            }
            int x6 = x2;
            int y6 = y3;
            label[q2] = new Label();
            label[q2].Text = Convert.ToString(sum1) + " $ Суммарная стоимость";
            label[q2].AutoSize = true;
            label[q2].Location = new Point(x6, y6);
            panel1.Controls.Add(label[q2]);


            file.Close();
        }

        private void DeleteEl(object sender, EventArgs e)
        {
            var Form = new DeleteForm(IndexName);
            Form.Show();
            this.Hide();              
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var Form1 = new Edit(IndexName);
            Form1.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }
    }

   
}
