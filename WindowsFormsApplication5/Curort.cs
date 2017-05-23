using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication5
{
    public partial class Curort : Form
    {
        static List<Massive> Mass = new List<Massive> { };
        static List<Curorts> Mass1 = new List<Curorts> { };
        static int sum=0;
        static Createcurort c = new Createcurort();
        public static Dictionary<int, RichTextBox> richTextBox = new Dictionary<int, RichTextBox>();
        public static Dictionary<int, RadioButton> radioButton = new Dictionary<int, RadioButton>();
        static int x1 = 10;
        static int y1 ;
        static int sum1 = 0;
        static int x3 = 265;
        static int y3;
        static bool a = true;
        static bool b = true;
        static Korzina Korzina = new Korzina();
        static int IndexName;
        static Seria Seria = new Seria();
        public Curort(int i)
        {
            IndexName = i;         
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //Seria.Out(@"4.xml", c.Mass1);
            c.Mass1 = Seria.In(@"4.xml", c.Mass1);
            Korzina = Seria.In(@"2.xml", Korzina);
            Mass = Seria.In(@"3.xml", Mass);
            foreach (var item in Mass)
            {
                foreach (var item1 in item.City)
                {
                    checkedListBox1.Items.Add(item1.Name);
                }
             
            }       
        }
        private void ShowCur(object sender, EventArgs e)
        {
            a = true;
            y1 = 10;           
            y3 = 5;
            panel1.Controls.Clear();
           
            for (int i = 0; i < c.Mass1.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < c.Mass1[i].City.Count; j++)
                {
                    for (int l = 0; l < checkedListBox1.CheckedItems.Count; l++)
                    {
                        if (checkedListBox1.CheckedItems[l].ToString() == c.Mass1[i].City[j])
                        {
                            sum++;
                        }
                    }
                 
                }
                if(sum == checkedListBox1.CheckedItems.Count)
                {
                    a = false;
                    richTextBox[i] = new RichTextBox();
                    richTextBox[i].Size =new Size(250,250);
                    richTextBox[i].ReadOnly = true;
                    richTextBox[i].Text = c.Mass1[i].Describe;
                    richTextBox[i].Location = new Point(x1, y1);    
                    radioButton[i] = new RadioButton();
                    radioButton[i].AutoEllipsis = true;
                    radioButton[i].AutoSize =true;
                    radioButton[i].Text = c.Mass1[i].CurortName;                  
                    radioButton[i].Location = new Point(x3, y3);
                    panel1.Controls.Add(richTextBox[i]);
                    panel1.Controls.Add(radioButton[i]);
                    y1 += 300;
                    y3 += 300;                  
                }                
            }
            if(a)
            {
                MessageBox.Show("Такого курорта нет");
            }                    
        }

        private void Curort_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Sum(object sender, EventArgs e)
        {
            sum1 = 0;
            for (int j = 0; j < c.Mass1.Count; j++)
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        if (((RadioButton)panel1.Controls[i]).Checked == true && ((RadioButton)panel1.Controls[i]).Text == c.Mass1[j].CurortName)
                        {
                            sum1 = sum1 + c.Mass1[j].Cost;
                        }
                    }
                }
            }
            if(sum1==0)
            {
                MessageBox.Show("Вы ничего не оплачиваете, выберите флажок");
                return;
            }
            label2.Text = "Цена:" + " " + Convert.ToString(sum1) + " $";              
        }

        private void Back(object sender, EventArgs e)
        {
          
            var c = new Main(IndexName);
            this.Hide();
            c.Show();
         
        }

        private void AddToKorzina(object sender, EventArgs e)
        {
            sum1 = 0;
            for (int j = 0; j < c.Mass1.Count; j++)
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        if (((RadioButton)panel1.Controls[i]).Checked == true && ((RadioButton)panel1.Controls[i]).Text == c.Mass1[j].CurortName)
                        {
                            sum1 = sum1 + c.Mass1[j].Cost;
                        }
                    }
                }
            }
            if (sum1 == 0)
            {
                MessageBox.Show("Вы ничего не оплачиваете, выберите флажок");
                return;
            }
            label2.Text = "Цена:" + " " + Convert.ToString(sum1) + " $";
            for (int i = 1; i < panel1.Controls.Count; i+=2)
            {
                if (((RadioButton)panel1.Controls[i]).Checked == true)
                {
                    Korzina.Hotel.Add(((RadioButton)panel1.Controls[i]).Text);
                    Korzina.Cost.Add(sum1);
                    Korzina.Index.Add(IndexName);
                    Seria.Out(@"2.xml", Korzina);
                    b = false;
                }
            }
            if(b)
            {
                MessageBox.Show("Вам нечего добавлять");
                return;
            }
        }

        private void GoToAddCur(object sender, EventArgs e)
        {
            var Form1 = new AddCur(IndexName);
            Form1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var Form = new DeleteCur(IndexName);
            Form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var Form = new EditCur(IndexName);
            Form.Show();
            this.Hide(); 
        }
    }
}
