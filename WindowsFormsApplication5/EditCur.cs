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
    public partial class EditCur : Form
    {
        static Seria Seria = new Seria();
        static Createcurort DataBase = new Createcurort();
        static string stroka = "";
        static int indexName;
        public EditCur(int i)
        {
            indexName = i;
            InitializeComponent();
        }

        private void EditCur_Load(object sender, EventArgs e)
        {
            
            DataBase.Mass1 = Seria.In(@"4.xml", DataBase.Mass1);
            foreach (var item in DataBase.Mass1)
            {
                comboBox1.Items.Add(item.CurortName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stroka = "";
            for (int i = 0; i < DataBase.Mass1.Count; i++)
            {
                if (comboBox1.Text == DataBase.Mass1[i].CurortName)
                {
                    for (int j = 0; j < DataBase.Mass1[i].City.Count; j++)
                    {
                        if (j == DataBase.Mass1[i].City.Count - 1)
                        {
                            stroka = stroka + DataBase.Mass1[i].City[j];
                        }
                        else
                        {
                            stroka = stroka + DataBase.Mass1[i].City[j] + ",";
                        }
                    }
                    textBox1.Text = stroka;
                    textBox2.Text = Convert.ToString(DataBase.Mass1[i].Cost);
                    textBox3.Text = comboBox1.Text;
                    richTextBox1.Text = DataBase.Mass1[i].Describe;
                }
            }
        }

        private void EditCur_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Mass = textBox1.Text.Split(',');
                List<string> City = new List<string> { };
                City.AddRange(Mass);

                for (int i = 0; i < DataBase.Mass1.Count; i++)
                {
                    if (comboBox1.Text == DataBase.Mass1[i].CurortName)
                    {
                        DataBase.Mass1[i].CurortName = textBox3.Text;
                        DataBase.Mass1[i].City.AddRange(City);
                        DataBase.Mass1[i].Cost = Convert.ToInt32(textBox2.Text);
                        DataBase.Mass1[i].Describe = richTextBox1.Text;
                    }

                }
                Seria.Out(@"4.xml", DataBase.Mass1);
            }
            catch
            {
                MessageBox.Show("Введите правильно информацию");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form = new Curort(indexName);
            Form.Show();
            this.Hide();
        }
    }
}
