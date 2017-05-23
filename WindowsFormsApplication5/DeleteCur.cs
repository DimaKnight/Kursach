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
    public partial class DeleteCur : Form
    {
        static Createcurort List = new Createcurort();
        static int IndexName;
        static Seria Seria = new Seria();
        public DeleteCur(int i)
        {
            IndexName = i;
            InitializeComponent();
        }

        private void DeleteCur_Load(object sender, EventArgs e)
        {
            List.Mass1 = Seria.In(@"4.xml", List.Mass1);
            for (int i = 0; i < List.Mass1.Count(); i++)
            {
                comboBox1.Items.Add(List.Mass1[i].CurortName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form = new Curort(IndexName);
            Form.Show();
            this.Hide();
        }

        private void DeleteCur_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List.Mass1.RemoveAt(comboBox1.SelectedIndex);
                Seria.Out(@"4.xml", List.Mass1);
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);

            }
            catch
            {
                MessageBox.Show("Выберите елемент");
            }
        }
    }
}
