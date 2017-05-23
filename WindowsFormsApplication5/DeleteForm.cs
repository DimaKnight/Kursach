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
    public partial class DeleteForm : Form
    {
        static CountryDataBase List = new CountryDataBase();
        static List<Massive> Mass = new List<Massive> { };    
        static int IndexName;
        static Seria Seria = new Seria();
        public DeleteForm(int i)
        {
            IndexName = i;
            InitializeComponent();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            List.Mass = Seria.In(@"3.xml", Mass);
            for (int i = 0; i < List.Mass.Count(); i++)
            {
                comboBox1.Items.Add(List.Mass[i].Country);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List.Mass.RemoveAt(comboBox1.SelectedIndex);
                Seria.Out(@"3.xml", List.Mass);
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                
            }
            catch
            {
                MessageBox.Show("Выберите елемент");
            }
        }

        private void DeleteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form = new Main(IndexName);
            Form.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
