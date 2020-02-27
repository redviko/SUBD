using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "name";
            listBox2.DisplayMember = "name";
            Biblioteka knigga= new Biblioteka("Nevagno","Wtf","Genre","1234231","ERA", "Мягкий", "ОтВерблюда","2019","2000","0/10 Burhable","1990" );
            Biblioteka knigga2= new Biblioteka("bruh","who","gog","2332-123","POP","Мягкий","ОтБога","с 2001 года","2000","11/10 Шедеврально","10000");
            listBox1.Items.Add(knigga);
            listBox1.Items.Add(knigga2);
            // listBox1.BeginUpdate();
            // var bruh= listBox1.Items.Cast<Biblioteka>().AsParallel().AsOrdered().OrderBy(biblioteka => biblioteka.Name);   //Код для будущей сортировки
            // var savedBruh = bruh.ToArray();
            // Thread.Sleep(1000);
            // listBox1.Items.Clear();
            // listBox1.Items.AddRange(savedBruh.ToArray());
            // listBox1.EndUpdate();
            //-----------------------------------------------------------//Нужный участок кода
            // if (ReadFile())
            // {
            //     MessageBox.Show("Успешно загружено");
            // }
            // else
            // {
            //     MessageBox.Show("Что-то пошло не так. Произвожу закрытие программы");
            //     // Close();
            // }
        } //Загрузка формы

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e) //Считывание из файла
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog() != DialogResult.Cancel)
                {
                    listBox1.Items.Clear();
                    File.OpenText(open.FileName).ReadLine().Contains("4");
                    File.
                    string[] allBookStrings = File.ReadAllLines(open.FileName, Encoding.Default);
                    if (allBookStrings.Length != 0)
                    {
                        foreach (string bookString in allBookStrings)
                        {
                            string[] booksSplit = bookString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (booksSplit.Length != 11)
                            {
                                MessageBox.Show("Запись повреждена");
                            }
                            else
                            {
                                Biblioteka book = new Biblioteka(booksSplit[0], booksSplit[1], booksSplit[2], booksSplit[4],
                                    booksSplit[5], booksSplit[6], booksSplit[7], booksSplit[8], booksSplit[9], booksSplit[10],
                                    booksSplit[3]);
                                listBox1.Items.Add(book);
                            }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нечего считывать(((");
                    }
                }
                else
                {
                    MessageBox.Show("Вы решили не выбирать файл");
                }
            }
            catch (Exception eexException)
            {
                MessageBox.Show($"Ошибка: {eexException.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e) //Поиск по ListBox
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
                    listBox1.Visible = false;
                    listBox2.Items.AddRange(result.ToArray());
                    listBox2.EndUpdate();
                }
                else
                {
                    listBox2.SelectedIndex = -1;
                    listBox1.Visible = true;

                }
            }
            catch (Exception aException)
            {
                MessageBox.Show($"Ошибка:{aException.Message}");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Add add=new Add();
                add.ShowDialog();
                File.AppendAllText($"C:\\Users\\User\\Documents\\LabResources\\BD.txt",Biblioteka.TempBiblioteka.ToString(), Encoding.Default);
                listBox1.Items.Add(Biblioteka.TempBiblioteka);
                Biblioteka.TempBiblioteka = new Biblioteka();
                //toolStripMenuItem1_Click(sender, EventArgs.Empty); //Вызов считывания файла
                MessageBox.Show("Добавлено");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка {exception.Message}");
            }
        }
    }
}


//private void textBox1_TextChanged(object sender, EventArgs e) //Поиск по ListBox
//{
//    try
//    {
//        if (textBox1.TextLength != 0 && listBox1.Items.Count != 0)
//        {
//            listBox1.SelectedIndex = -1;
//            listBox2.BeginUpdate();
//            listBox2.Items.Clear();
//            var result = from knigga in listBox1.Items.Cast<Biblioteka>().AsParallel()
//                         where knigga.Name.ToLower().Contains(textBox1.Text.ToLower()) || knigga.Genre.ToLower().Contains(textBox1.Text.ToLower()) ||
//                               knigga.Authors.ToLower().Contains(textBox1.Text.ToLower())
//                         select knigga;
//            //foreach (Biblioteka biblioteka in result) //Проверочный КОД. Не трогать без причины;
//            //{
//            //    int i=0;
//            //    i++;
//            //}

//            listBox1.Visible = false;
//            listBox2.Items.AddRange(result.ToArray());
//            listBox2.EndUpdate();
//        }
//        else
//        {
//            listBox2.SelectedIndex = -1;
//            //MessageBox.Show("Либо в листбоксе нет элементов, либо строка поиска стала пустой"); //Разделить случай когда ничего не введено и когда нет элементов в листбоксе
//            listBox1.Visible = true;

//        }
//    }
//    catch (Exception aException)
//    {
//        MessageBox.Show($"Ошибка:{aException.Message}");
//    }
//}