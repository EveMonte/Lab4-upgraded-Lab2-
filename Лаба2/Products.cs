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
        public Discipline ShallowCopy()
        {
            return (Discipline)this.MemberwiseClone();
        }

        public Discipline DeepCopy()
        {
            Discipline clone = (Discipline)this.MemberwiseClone();
            clone.lecturer = new Lecturer();
            clone.listOfLiterature = new Book();
            clone.Name = String.Copy(Name);
            clone.Speciality = String.Copy(Speciality);
            clone.TypeOfControl = String.Copy(TypeOfControl);
            clone.lecturer.SecondName = String.Copy(lecturer.SecondName);
            clone.lecturer.Name = String.Copy(lecturer.Name);
            clone.lecturer.Patronymic = String.Copy(lecturer.Patronymic);
            clone.lecturer.Chair = String.Copy(lecturer.Chair);
            clone.lecturer.Auditory = String.Copy(lecturer.Auditory);
            clone.listOfLiterature.Author = String.Copy(listOfLiterature.Author);
            clone.listOfLiterature.Name = String.Copy(listOfLiterature.Name);


            return clone;
        }
    }
}
