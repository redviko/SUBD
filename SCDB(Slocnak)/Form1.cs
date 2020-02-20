using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCDB_Slocnak_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "name";
            Biblioteka knigga= new Biblioteka("Nevagno","Wtf","Genre","1234231","ERA", DateTime.Today, new DateTime(2000,2,13),"0/10 Гавно вообщем:D" );
            Biblioteka knigga2= new Biblioteka("ppppp","xxxxxx","zzzzzz","123123123","Hui Znaet", DateTime.Today, DateTime.Today, "Жесть");
            Biblioteka knigga3= new Biblioteka("zN","qweqwes","dqweqweeqw","5837491-2","Fade Summer", DateTime.Today, DateTime.Today, "11/10 qwe");
            listBox1.Items.Add(knigga);
            listBox1.Items.Add(knigga2);
            listBox1.Items.Add(knigga3);
            // if (ReadFile())
            // {
            //     MessageBox.Show("Успешно загружено");
            // }
            // else
            // {
            //     MessageBox.Show("Что-то пошло не так. Произвожу закрытие программы");
            //     // Close();
            // }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength!=0&&listBox1.Items.Count!=0)
            {
                listBox1.BeginUpdate();
                //listBox1.Items.Clear();
                var result = from knigga in listBox1.Items.Cast<Biblioteka>().AsParallel()
                    //from author in knigga.Authors
                    //from genre in knigga.Genre
                    where knigga.Name.Contains(textBox1.Text) || knigga.Genre.Contains(textBox1.Text) ||
                          knigga.Authors.Contains(textBox1.Text)
                    //where author.ToString().Contains(textBox1.Text)
                    //where genre.ToString().Contains(textBox1.Text)
                    select knigga;
                foreach (Biblioteka biblioteka in result)
                {
                    int i=0;
                    i++;
                }
                     listBox1.Items.AddRange(result.ToArray());
                listBox1.EndUpdate();
            }
            else
            {
                
            }
        }

        /*private bool ReadFile()
        {
            try
            {
                if (File.Exists("C:\\Users\\User\\Documents\\LabResources\\BD.txt"))
                {
                    if (File.ReadAllText("C:C:\\Users\\User\\Documents\\LabResources\\BD.txt", Encoding.Default).Length!=0)
                    {
                        String[] attributeStrings =
                            File.ReadAllText("C:\\Users\\User\\Documents\\LabResources\\BD.txt", Encoding.Default)
                                .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);


                    }
                    else
                    {
                        MessageBox.Show("Файл пустой");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Файла не существует");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка:{e.Message}");
                return false;
            }
        }*/
    }
}
