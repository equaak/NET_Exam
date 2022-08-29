using System;
using System.Windows.Forms;

namespace Exam
{
    public partial class DeleteBook : Form
    {
        private string name;
        private Books book;
        public DeleteBook()
        {
            InitializeComponent();
            using (var db = new BookShopEntities1())
            {
                foreach (var item in db.Set<Books>())
                {
                    comboBox1.Items.Add(item.BookName);
                }
            }
                
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new BookShopEntities1())
            {
                if(name != String.Empty)
                {
                    //var Book = db.Users.
                    var Books = db.Set<Books>();

                    foreach(var item in Books)
                    {
                        if(item.BookName == name)
                        {
                            book = item;
                        }
                    }

                    if(book != null)
                    {
                        db.Books.Remove(book);
                        comboBox1.Items.Remove(name);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("U dont have this book in store to delete");
                        var page = new Menu();
                        this.Hide();
                        page.ShowDialog();
                        this.Close();
                    }

                    MessageBox.Show("Successfully deleted book");
                }
                else
                {
                    MessageBox.Show("Choose book from database");
                }
            }
        }
    }
}
