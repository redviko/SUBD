using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCDB_Slocnak_
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            Biblioteka kniga = Biblioteka.TempBiblioteka;
            textBox1.Text = kniga.Name;
            textBox2.Text = kniga.Authors;
            textBox3.Text = kniga.Genre;
            textBox8.Text = kniga.DateOfPublishing;
            textBox4.Text = kniga.ISBN;
            textBox5.Text = kniga.Publishing;
            textBox6.Text = kniga.Sourse;
            comboBox1.Text = kniga.Binding;
            textBox9.Text = kniga.DateInLibraryDateTime;
            textBox10.Text = kniga.DateOfReading;
            textBox7.Text = kniga.Comment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Biblioteka kniga = new Biblioteka();
                kniga.Name = textBox1.Text;
                kniga.Authors = textBox2.Text;
                kniga.Genre = textBox3.Text;
                kniga.DateOfPublishing = textBox8.Text;
                kniga.ISBN = textBox4.Text;
                kniga.Publishing = textBox5.Text;
                kniga.Sourse = textBox6.Text;
                kniga.Binding = comboBox1.Text;
                kniga.DateInLibraryDateTime = textBox9.Text;
                kniga.DateOfReading = textBox10.Text;
                kniga.Comment = textBox7.Text;
                Biblioteka.TempBiblioteka = kniga;
                Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка: {exception.Message}");
            }
        }
    }
}
