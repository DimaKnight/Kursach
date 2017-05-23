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
    public partial class Edit : Form
    {
        static Seria seria = new Seria();
        static CountryDataBase DataBase = new CountryDataBase();
        static int IndexName;
        public Edit(int i)
        {
            IndexName = i;
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
        DataBase.Mass= seria.In(@"3.xml", DataBase.Mass);
            foreach (var item in DataBase.Mass)
            {
                comboBox1.Items.Add(item.Country);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in DataBase.Mass)
            {
                if(comboBox1.Text==item.Country)
                { 
                    textBox1.Text = comboBox1.Text;
                    foreach (var item1 in item.City)
                    {
                        comboBox2.Items.Add(item1.Name);
                    }
                  
                }
            }
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in DataBase.Mass)
            {
                foreach (var item1 in item.City)
                {
                    if (comboBox2.Text == item1.Name)
                    {
                        textBox2.Text = comboBox2.Text;
                        foreach (var item2 in item1.Hotel)
                        {
                            comboBox4.Items.Add(item2.Name);
                        }
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in DataBase.Mass)
            {
                foreach (var item1 in item.City)
                {
                    foreach (var item2 in item1.Hotel)
                    {
                        if(item2.Name==comboBox4.Text)
                        {
                            textBox3.Text = item2.Name;
                            textBox4.Text = Convert.ToString(item2.Cost);
                            richTextBox1.Text = item2.Describe;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DataBase.Mass.Count; i++)
                {
                    if (DataBase.Mass[i].Country == comboBox1.Text)
                    {
                        DataBase.Mass[i].Country = textBox1.Text;
                    }
                    for (int j = 0; j < DataBase.Mass[i].City.Count; j++)
                    {
                        if (DataBase.Mass[i].City[j].Name == comboBox2.Text)
                        {
                            DataBase.Mass[i].City[j].Name = textBox2.Text;
                        }
                        for (int l = 0; l < DataBase.Mass[i].City[j].Hotel.Count; l++)
                        {
                            if (DataBase.Mass[i].City[j].Hotel[l].Name == comboBox4.Text)
                            {
                                DataBase.Mass[i].City[j].Hotel[l].Name = textBox3.Text;
                                DataBase.Mass[i].City[j].Hotel[l].Cost = Convert.ToInt32(textBox4.Text);
                                DataBase.Mass[i].City[j].Hotel[l].Describe = richTextBox1.Text;
                            }
                        }
                    }
                }
                seria.Out(@"3.xml", DataBase.Mass);
            }
            catch
            {
                MessageBox.Show("Введите правильно информацию");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Main(IndexName);
            form.Show();
            this.Hide();
        }
    }
}
