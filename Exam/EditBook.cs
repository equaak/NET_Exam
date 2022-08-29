using System;
using System.Windows.Forms;

namespace Exam
{
    public partial class EditBook : Form
    {
        private Books newBook = new Books();
        public EditBook(Books book)
        {
            InitializeComponent();
            newBook = book;
            textBox1.Text = newBook.BookName;
            textBox2.Text = newBook.Author;
            textBox3.Text = newBook.Publisher;
            textBox4.Text = newBook.PageNumber.ToString();
            label5.Text = newBook.IsContinue == true ? "Book is continue of thrilogy" : "Book isn't continue of thrilogy";
            comboBox1.Items.Add("Book is continue of thrilogy");
            comboBox1.Items.Add("Book isn't continue of thrilogy");
        }

        private void EditBook_Load(object sender, EventArgs e)
        { 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newBook.BookName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            newBook.Author = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            newBook.Publisher = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            newBook.PageNumber = Int32.Parse(textBox4.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
