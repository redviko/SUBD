using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = new List<string>();
            string authors = "Авторы.txt";
            string slova = "Рус.txt";
            string janr = "Жанры.txt";
            string izdatel = "Издатели.txt";
            string mark1 = "Mark.txt";
            string mark2 = "Комменты.txt";
            string basa = "БД.txt";
            List<string> pereplet = new List<string>();
            pereplet.Add("твердый");
            pereplet.Add("мягкий");
            List<string> istochnik = new List<string>();
            istochnik.Add("покупка");
            istochnik.Add("подарок");
            istochnik.Add("наследство");
            istochnik.Add("находка");
            istochnik.Add("обмен");
            Random rnd = new Random();
            List<string> Author = new List<string>();
            Author.AddRange(File.ReadAllLines(authors));
            List<string> Slova = new List<string>();
            Slova.AddRange(File.ReadAllLines(slova));
            List<string> Janr = new List<string>();
            Janr.AddRange(File.ReadAllLines(janr));
            List<string> Izdatel = new List<string>();
            Izdatel.AddRange(File.ReadAllLines(izdatel));
            List<string> Mark1 = new List<string>();
            Mark1.AddRange(File.ReadAllLines(mark1));
            List<string> Mark2 = new List<string>();
            Mark2.AddRange(File.ReadAllLines(mark2));
            for (int i = 0; i < 10000; i++)
            {
                string text = "";
                text += $"{i.ToString()};";
                int m = rnd.Next(1, 4);
                for (int j = 0; j < m; j++)
                    text += Slova[rnd.Next(0, Slova.Count)] + " ";
                text += ";";
                m = rnd.Next(1, 3);
                for (int j = 0; j < m; j++)
                {
                    text += Author[rnd.Next(0, Author.Count)];
                    if (j != m - 1)
                        text += ",";
                }

                text += ";";
                text += Janr[rnd.Next(0, Janr.Count)];
                text += ";";
                int year = rnd.Next(1900, 2020);
                text += year;
                text += ";";
                for (int j = 0; j < 4; j++)
                    text += rnd.Next(10, 100);
                text += ";";
                text += Izdatel[rnd.Next(0, Izdatel.Count)];
                text += ";";
                text += pereplet[rnd.Next(0, pereplet.Count)];
                text += ";";
                text += istochnik[rnd.Next(0, istochnik.Count)];
                text += ";";
                int day1 = rnd.Next(1, 29);
                int mounth1 = rnd.Next(1, 13);
                int year1 = rnd.Next(year, 2020);
                int day2 = rnd.Next(1, 31);
                int mounth2 = rnd.Next(1, 13);
                int year2 = rnd.Next(year1, 2020);
                DateTime date1 = new DateTime(year1, mounth1, day1);
                DateTime date2;
                try
                {
                    date2 = new DateTime(year2, mounth2, day2);
                }
                catch
                {
                    date2 = DateTime.MinValue;
                }

                if (date2 < date1)
                    date2 = DateTime.MinValue;
                text += date1.ToString("dd.MM.yyyy");
                text += ";";
                text += date2.ToString("dd.MM.yyyy");
                text += ";";
                text += Mark1[rnd.Next(0, Mark1.Count)];
                text += " " + Mark2[rnd.Next(0, Mark2.Count)];
                text += "\r\n";
                //if (i != 9999)
                //    text += "";
                books.Add(text);
            }

            string txt = "";
            for (int i = 0; i < books.Count; i++)
            {
                txt += books[i];
            }

            File.WriteAllText(basa, txt);
        }
    }
}

