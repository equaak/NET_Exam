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
    public partial class SingUpPage : Form
    {
        private string NUserName = null;
        private string NPassword = null;
        public SingUpPage()
        {
            InitializeComponent();
        }

        private void SingUpPage_Load(object sender, EventArgs e)
        {

        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            NUserName = textBox.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NPassword = textBox.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(var db = new BookShopEntities1())
            {
                var users = db.Set<Users>();
                
                if(NUserName != String.Empty && NPassword != String.Empty)
                {
                    foreach(var user in users)
                    {
                        if(user.UserName == NUserName)
                        {
                            MessageBox.Show("We already had user with this username");
                            this.Close();
                            return;
                        }
                    }

                    users.Add(new Users { UserName = NUserName, UPassword = NPassword });

                    db.SaveChanges();

                    MessageBox.Show("Successful sign up!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LoginPage loginpage = new LoginPage();
            //this.Hide();
            //loginpage.Show();
        }
    }
}
