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
   
    
    public partial class LogInForm : Form
    {
      
        static CreateList MyList = new CreateList();
        static Seria Seria = new Seria();
        static bool a=false;

        public LogInForm()
        {           
            InitializeComponent();
        }
       
        private void LogIn(object sender, EventArgs e)
        {
                if (ButReg.Visible == true)
                    back.Visible = true;
                else
                    back.Visible = false;
                ButEnter.Hide();
                ButReg.Hide();
                WrName.Show();
                WrPass.Show();
                Enter.Show();
                Enter1.Show();
                Okenter.Show();
                Okreg.Hide();
                WrName.Clear();
                WrPass.Clear();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            if (ButReg.Visible == true)
                back.Visible =false;
            else
                back.Visible = true;
            WrName.Hide();
            WrPass.Hide();
            Enter.Hide();
            Enter1.Hide();
            Reges.Hide();
            Reges1.Hide();
            Okenter.Hide();
            Okreg.Hide();
            MyList=Seria.In("1.xml", MyList);
        }

        public void OkLogIn(object sender, EventArgs e)
        {            
            if(WrName.Text=="")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (WrPass.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            for (int i = 0; i < MyList.ListName.Count(); i++)
            {
                if (MyList.ListName[i] == WrName.Text && MyList.ListPassword[i] == WrPass.Text)
                {
                    
                    MessageBox.Show("Добро пожаловать");
                    this.Hide();
                    Form c1 = new Main(i);
                    c1.Show();
                    break;              
                }
            }
            for (int i = 0; i < MyList.ListName.Count(); i++)
            {
                if (WrName.Text==MyList.ListName[i] && WrPass.Text==MyList.ListPassword[i])
                {
                    a = true;
                   
                }                
            }
            if(!a)
            {
                MessageBox.Show("Неверный юзер");
                return;
            }
        }

        private void Reg(object sender, EventArgs e)
        {
            if (ButReg.Visible == true)
                back.Visible = true;
            else
                back.Visible = false;
            ButEnter.Hide();
            ButReg.Hide();
            WrName.Show();
            WrPass.Show();
            Reges.Show();
            Reges1.Show();
            Okenter.Hide();
            Okreg.Show();
            WrName.Clear();
            WrPass.Clear();
        }

        private void Back(object sender, EventArgs e)
        {
            if (ButReg.Visible == true)
                back.Visible = true;
            else
                back.Visible = false;
            ButEnter.Show();
            ButReg.Show();
            WrName.Hide();
            WrPass.Hide();
            Enter.Hide();
            Enter1.Hide();
            Reges.Hide();
            Reges1.Hide();
            Okenter.Hide();
            Okreg.Hide();
            WrName.Clear();
            WrPass.Clear();
        }
       
        public void OkReg(object sender, EventArgs e)
        {
            
            if (WrName.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (WrPass.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            foreach (var item in MyList.ListName)
            {
                if (WrName.Text == item)
                {
                    MessageBox.Show("Такой пользователь уже есть");
                    return;
                }
            }
            MessageBox.Show("Теперь вы можете зайти");
           
            MyList.ListName.Add(WrName.Text);
            MyList.ListPassword.Add(WrPass.Text);

            Seria.Out("1.xml", MyList);
        }

        private void LogInForm_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LogInForm_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Okreg.Visible == false)
                    OkLogIn(sender, e);
                else
                    OkReg(sender, e);
            }
        }

    }
 
}
