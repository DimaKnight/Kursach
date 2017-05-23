using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class AddCur : Form
    {
        static Createcurort Curort = new Createcurort();
        static List<Curorts> Mass1 = new List<Curorts> { };
        static int sum = 0;
        static int IndexName;
        static Seria Seria = new Seria();
        public AddCur(int i)
        {
            IndexName = i;
            InitializeComponent();
        }

        private void AddCur123(object sender, EventArgs e)
        {
            sum = 0;
            try
            {
                string[] a = textBox2.Text.Split(',');
                List<string> b = new List<string> { };
                b.AddRange(a);
                for (int i = 0; i < Curort.Mass1.Count(); i++)
                {
                    if (textBox1.Text == Curort.Mass1[i].CurortName)
                    {
                        sum++;
                        MessageBox.Show("Такой курорт уже есть");
                        return;
                    }
                }
                if (sum == 0)
                {
                    Curort.Mass1.Add(new Curorts(textBox1.Text, b, Convert.ToInt32(textBox3.Text), richTextBox1.Text));
                    Seria.Out(@"4.xml",Curort.Mass1);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Введите правильно");
                return;
                    
            }
           
        }

        private void Back(object sender, EventArgs e)
        {
            var Form = new Curort(IndexName);
            Form.Show();
            this.Hide();
        }

        private void AddCur_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddCur_Load(object sender, EventArgs e)
        {
           Curort.Mass1 = Seria.In(@"4.xml", Curort.Mass1);
        }
    }
}
