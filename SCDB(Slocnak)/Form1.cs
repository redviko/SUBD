using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            listBox2.DisplayMember = "name";
            Biblioteka knigga= new Biblioteka("Nevagno","Wtf","Genre","1234231","ERA", "Мягкий", "ОтВерблюда","2019","2000","0/10 Burhable","1990" );
            listBox1.Items.Add(knigga);
            //listBox1.Items.Add(knigga2);
            //listBox1.Items.Add(knigga3);
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

        private void textBox1_TextChanged(object sender, EventArgs e) //Поиск по ListBox
        {
            try
            {
                if (textBox1.TextLength != 0 && listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = -1;
                    listBox2.BeginUpdate();
                    listBox2.Items.Clear();
                    var result = from knigga in listBox1.Items.Cast<Biblioteka>().AsParallel()
                                 where knigga.Name.ToLower().Contains(textBox1.Text.ToLower()) || knigga.Genre.ToLower().Contains(textBox1.Text.ToLower()) ||
                                       knigga.Authors.ToLower().Contains(textBox1.Text.ToLower())
                                 select knigga;
                    //foreach (Biblioteka biblioteka in result) //Проверочный КОД. Не трогать без причины;
                    //{
                    //    int i=0;
                    //    i++;
                    //}

                    listBox1.Visible = false;
                    listBox2.Items.AddRange(result.ToArray());
                    listBox2.EndUpdate();
                }
                else
                {
                    listBox2.SelectedIndex = -1;
                    //MessageBox.Show("Либо в листбоксе нет элементов, либо строка поиска стала пустой"); //Разделить случай когда ничего не введено и когда нет элементов в листбоксе
                    listBox1.Visible = true;

                }
            }
            catch (Exception aException)
            {
                MessageBox.Show($"Ошибка:{aException.Message}");
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //Вывод информации об объектах из неотсортированного
        {
            if (listBox1.SelectedIndex!=-1)
            {
                Biblioteka biblioteka =(Biblioteka) listBox1.SelectedItem;
                label12.Text = biblioteka.Name;
                label13.Text = biblioteka.Authors;
                label14.Text = biblioteka.Genre;
                label15.Text = biblioteka.DateOfPublishing;
                label16.Text = biblioteka.ISBN;
                label17.Text = biblioteka.Publishing;
                label18.Text = biblioteka.Binding;
                label19.Text = biblioteka.Sourse;
                label20.Text = biblioteka.DateInLibraryDateTime;
                label21.Text = biblioteka.DateOfReading;
                label22.Text = biblioteka.Comment;
            }
            else
            {
                label12.Text = String.Empty;
                label13.Text = String.Empty;
                label14.Text = String.Empty;
                label15.Text = String.Empty;
                label16.Text = String.Empty;
                label17.Text = String.Empty; ;
                label18.Text = String.Empty;
                label19.Text = String.Empty;
                label20.Text = String.Empty;
                label21.Text = String.Empty;
                label22.Text = String.Empty;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //Вывод информации по книгам из отсортированного листбокса
        {
            if (listBox2.SelectedIndex!=-1)
            {
                Biblioteka biblioteka = (Biblioteka)listBox2.SelectedItem;
                label12.Text = biblioteka.Name;
                label13.Text = biblioteka.Authors;
                label14.Text = biblioteka.Genre;
                label15.Text = biblioteka.DateOfPublishing;
                label16.Text = biblioteka.ISBN;
                label17.Text = biblioteka.Publishing;
                label18.Text = biblioteka.Binding;
                label19.Text = biblioteka.Sourse;
                label20.Text = biblioteka.DateInLibraryDateTime;
                label21.Text = biblioteka.DateOfReading;
                label22.Text = biblioteka.Comment;
            }
            else
            {
                label12.Text = String.Empty;
                label13.Text = String.Empty;
                label14.Text = String.Empty;
                label15.Text = String.Empty;
                label16.Text = String.Empty;
                label17.Text = String.Empty; ;
                label18.Text = String.Empty;
                label19.Text = String.Empty;
                label20.Text = String.Empty;
                label21.Text = String.Empty;
                label22.Text = String.Empty;
            }
        }
    }
}
