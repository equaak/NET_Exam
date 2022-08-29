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
    public partial class ChooseBook : Form
    {
        private string bookName = null;
        public ChooseBook()
        {
            InitializeComponent();
            using(var db = new BookShopEntities1())
            {
                var books = db.Set<Books>();
                foreach(var item in books)
                {
                    comboBox1.Items.Add(item.BookName);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookName = comboBox1.Text;
        }
    }
}
