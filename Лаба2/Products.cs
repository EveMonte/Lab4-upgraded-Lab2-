using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2
{
    //Конкретные продукты
    [Serializable]
    public class Book : IAbstractBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime date { get; set; }
    }

    [Serializable]
    public class Lecturer : IAbstractLecturer
    {
        public string Chair { get; set; }//such an interesting translation by Google Translator
        public string SecondName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Auditory { get; set; }
    }
    [Serializable]
    public class Discipline : IAbstractDiscipline
    {
        public string Name
        {
            get;
            set;
        }
        public int Semestr
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;
        }
        public string Speciality
        {
            get;
            set;
        }
        public int NumberOfLections
        {
            get;
            set;
        }
        public int NumberOfLaboratories { get; set; }
        public string TypeOfControl { get; set; }

        public Lecturer lecturer;
        public Book listOfLiterature;
        public void AddLecturer(IAbstractLecturer abstractLecturer)
        {
            lecturer = (Lecturer)abstractLecturer;
        }
        public void AddBook(IAbstractBook abstractBook)
        {
            listOfLiterature = (Book)abstractBook;
        }
    }
}
