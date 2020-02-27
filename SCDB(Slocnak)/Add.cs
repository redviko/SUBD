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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                    Biblioteka knigga = new Biblioteka();
                    knigga.Name = textBox1.Text;
                    knigga.Authors = textBox2.Text;
                    knigga.DateOfPublishing = dateTimePicker1.Value.Year.ToString();
                    knigga.Genre = textBox3.Text;
                    knigga.ISBN = textBox5.Text;
                    knigga.Publishing = textBox6.Text;
                    knigga.Binding = comboBox1.Text;
                    knigga.Sourse = textBox8.Text;
                    knigga.DateInLibraryDateTime = dateTimePicker2.Value.ToString("d");
                    knigga.DateOfReading = dateTimePicker3.Value.ToString("d");
                    knigga.Comment = textBox11.Text;
                    Biblioteka.TempBiblioteka = knigga;
                    Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка: {exception.Message}");
            }
        }
    }
}
