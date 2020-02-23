using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDB_Slocnak_
{
    class Biblioteka
    {
        // private static List<Biblioteka> booksList = new List<Biblioteka>();
        public String Name { get; set; }
        public String Authors { get; set; }
        public String Genre { get; set; }
        public String ISBN { get; set; }
        public String Publishing { get; set; }
        public string Binding { get; set; }

        public String Sourse { get; set; }

        public string DateInLibraryDateTime { get; set; }

        public string DateOfReading { get; set; }
        public String Comment { get; set; }
        public String DateOfPublishing { get; set; }

        public Biblioteka(string name, string authors, string genre, string iSBN, string publishing, string binding, string sourse, string dateInLibraryDateTime, string dateOfReading, string comment, string dateOfPublishing)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Authors = authors ?? throw new ArgumentNullException(nameof(authors));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            Publishing = publishing ?? throw new ArgumentNullException(nameof(publishing));
            Binding = binding ?? throw new ArgumentNullException(nameof(binding));
            Sourse = sourse ?? throw new ArgumentNullException(nameof(sourse));
            DateInLibraryDateTime = dateInLibraryDateTime ?? throw new ArgumentNullException(nameof(dateInLibraryDateTime));
            DateOfReading = dateOfReading ?? throw new ArgumentNullException(nameof(dateOfReading));
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            DateOfPublishing = dateOfPublishing ?? throw new ArgumentNullException(nameof(dateOfPublishing));
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
