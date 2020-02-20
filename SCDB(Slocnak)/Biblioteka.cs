using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDB_Slocnak_
{
    class Biblioteka
    {
        public static List<Biblioteka> booksList = new List<Biblioteka>();
        public String Name { get; set; }
        public String Authors { get; set; }
        public String Genre { get; set; }
        public String ISBN { get; set; }
        public String Publishing { get; set; }
        public String[] Binding { get; } = { "Твёрдый", "Мягкий" };

        public String[] Source { get; } = {"Покупа", "Подарок", "Наследство"};

        public DateTime DateInLibraryDateTime { get; set; }

        public DateTime DateOfReading { get; set; }
        public String Comment { get; set; }

        public Biblioteka(string name, string authors, string genre, string iSBN, string publishing, /*string[] binding, string[] source,*/ DateTime dateInLibraryDateTime, DateTime dateOfReading, string comment)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Authors = authors ?? throw new ArgumentNullException(nameof(authors));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            Publishing = publishing ?? throw new ArgumentNullException(nameof(publishing));
            //Binding = binding ?? throw new ArgumentNullException(nameof(binding));
            //Source = source ?? throw new ArgumentNullException(nameof(source));
            DateInLibraryDateTime = dateInLibraryDateTime;
            DateOfReading = dateOfReading;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public Biblioteka()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
