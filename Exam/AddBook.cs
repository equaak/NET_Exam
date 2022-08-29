using System;
using System.Windows.Forms;

namespace Exam
{
    public partial class AddBook : Form
    {
        private Books book = new Books();
        private string NBookName { get; set; }
        private string NAuthor { get; set; }
        private string NPublisher { get; set; }
        private int NPageNumber { get; set; }
        private bool NIsContinue { get; set; }
        private string NGenre { get; set; }
        private DateTime NPublishYear { get; set; }
        private int NSellPrice { get; set; }
        private int NOwnPrice { get; set; }
        public AddBook()
        {
            InitializeComponent();
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Yes");
            comboBox1.Items.Add("No");
            using(var db = new BookShopEntities1())
            {
                var Genres = db.Set<Genre>();
                foreach(var item in Genres)
                {
                    comboBox2.Items.Add(item.Genre1);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NBookName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            NAuthor = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            NPublisher = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text.Length < 5)
            {
                NPageNumber = Int32.Parse(textBox4.Text);
            }
            else
            {
                MessageBox.Show("Too many pages");
                textBox4.Text = NPageNumber.ToString();
                return;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(textBox8.Text.Length < 5)
            {
                NSellPrice = Int32.Parse(textBox8.Text);
            }
            else
            {
                MessageBox.Show("Too expensive");
                textBox8.Text = NSellPrice.ToString();
                return;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if(textBox9.Text.Length < 5)
            {
                NOwnPrice = Int32.Parse(textBox9.Text);
            }
            else
            {
                MessageBox.Show("Too expensive");
                textBox9.Text = NOwnPrice.ToString();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new BookShopEntities1())
            {
                var books = db.Set<Books>();

                if (NBookName != String.Empty)
                {

                    foreach(var book in books)
                    {
                        if(NBookName == book.BookName)
                        {
                            MessageBox.Show("We already have this book");
                            this.Close();
                            return;
                        }
                    }

                    books.Add(new Books { Author = NAuthor, BookName = NBookName, IsContinue = NIsContinue, Genre = NGenre, OwnPrice = NOwnPrice, PageNumber = NPageNumber, Publisher = NPublisher, PublishYear = NPublishYear, SellPrice = NSellPrice });
                    db.SaveChanges();
                    MessageBox.Show("Successfully added book");
                }
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NIsContinue = comboBox1.SelectedIndex == 0 ? true : false;
            MessageBox.Show(NIsContinue.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Items.Count > 0)
            {
                NGenre = comboBox2.Text;
                MessageBox.Show(NGenre.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            NPublishYear = DateTime.Parse(dateTimePicker1.Text);
            MessageBox.Show(NPublishYear.ToString());
        }
    }
}
