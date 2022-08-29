using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class LoginPage : Form
    {
        private string Username = null;
        private string Password = null;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Connection complete!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Username = textBox.Text;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Password = textBox1.Text;
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new BookShopEntities1())
            {
                if(Username != String.Empty)
                {
                    var User = db.Users.FirstOrDefault(user => user.UserName.Equals(Username));
                    if(User != null)
                    {
                        if (User.UPassword.Equals(Password))
                        {
                            Menu page = new Menu();
                            MessageBox.Show("Successful login");
                            this.Hide();
                            page.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login error");
                        }
                    }
                    if(User == null)
                    {
                        MessageBox.Show("It seems like u have error in data");
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SingUpPage signup = new SingUpPage();
            this.Hide();
            signup.ShowDialog();
            this.Close();
        }
    }
}
