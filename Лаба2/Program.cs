using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба2
{
    public interface IBuilder
    {
        void BuildDisciplineNameAndTypePart(string disName, string typeOfControl);
        void BuildNumbersPart(int lections, int laboratories);
        void BuildProgressAndSpecialityPart(int year, int semestr, string speciality);
        void BuildLecturerFIOPart(string second, string name, string patronymic);
        void BuildLecturerAnotherPart(string chair, string auditory);
        void BuildBookPart(string name, string author, DateTime dateTime);
    }

    public class ConcreteBuilder : IBuilder
    {
        private Discipline discipline = new Discipline();
        public ConcreteBuilder(Discipline dis)
        {
            this.Reset();
            discipline = dis;
        }
        public void Reset()
        {
            this.discipline = new Discipline();
        }

        public void BuildDisciplineNameAndTypePart(string disName, string typeOfControl)
        {
            discipline.Name = disName;
            discipline.TypeOfControl = typeOfControl;
        }
        public void BuildNumbersPart(int lections, int laboratories)
        {
            discipline.NumberOfLections = lections;
            discipline.NumberOfLaboratories = laboratories;
        }
        public void BuildProgressAndSpecialityPart(int year, int semestr, string speciality)
        {
            discipline.Year = year;
            discipline.Semestr = semestr;
            discipline.Speciality = speciality;
        }
        public void BuildLecturerFIOPart(string second, string name, string patronymic)
        {
            discipline.lecturer.SecondName = second;
            discipline.lecturer.Name = name;
            discipline.lecturer.Patronymic = patronymic;
        }
        public void BuildLecturerAnotherPart(string chair, string auditory)
        {
            discipline.lecturer.Chair = chair;
            discipline.lecturer.Auditory = auditory;
        }
        public void BuildBookPart(string name, string author, DateTime dateTime)
        {
            discipline.listOfLiterature.Name = name;
            discipline.listOfLiterature.Author = author;
            discipline.listOfLiterature.date = dateTime;
        }

        public Discipline GetResult()
        {
            Discipline result = this.discipline;
            this.Reset();
            return result;
        }
    }
    interface IAbstractFactory
    {
        IAbstractDiscipline CreateDiscipline();
        IAbstractLecturer CreateLecturer();
        IAbstractBook CreateBook();
    }

    interface IAbstractDiscipline
    {
        void AddLecturer(IAbstractLecturer lecturer);
        void AddBook(IAbstractBook book);
        string Name
        {
            get;
            set;
        }
        int Semestr
        {
            get;
            set;
        }
        int Year
        {
            get;
            set;
        }
        string Speciality
        {
            get;
            set;
        }
        int NumberOfLections
        {
            get;
            set;
        }
        int NumberOfLaboratories { get; set; }
        string TypeOfControl { get; set; }

    }

    public interface IAbstractLecturer
    {
        string Chair { get; set; }//such an interesting translation by Google Translator
        string SecondName { get; set; }
        string Name { get; set; }
        string Patronymic { get; set; }
        string Auditory { get; set; }
    }

    public interface IAbstractBook
    {
        string Name { get; set; }
        string Author { get; set; }
        DateTime date { get; set; }
    }

    [Serializable]
    public class Book : IAbstractBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime date { get; set; }
    }

    static class Finder 
    { 
        static public string FindElementsInForm(string elementsName, string elementsType, Form1 form)
        {
            switch (elementsType)
            {
                case "TextBox":
                    foreach(TextBox textBox in form.Controls)
                    {
                        if(textBox.Name == elementsName)
                        {
                            return textBox.Text;
                        }
                    }

                    break;
                case "ComboBox":
                    foreach (ComboBox comboBox in form.Controls)
                    {
                        if (comboBox.Name == elementsName)
                        {
                            return comboBox.Text;
                        }
                    }
                    break;
                case "ListBox":
                    foreach (ListBox listBox in form.Controls)
                    {
                        if (listBox.Name == elementsName)
                        {
                            return listBox.SelectedItem.ToString();
                        }
                    }
                    break;
                case "NumericUpDown":
                    foreach (NumericUpDown numericUpDown in form.Controls)
                    {
                        if (numericUpDown.Name == elementsName)
                        {
                            return numericUpDown.Text;
                        }
                    }
                    break;
            }
            return "";
        }
    }

    
    class ISITFactory : IAbstractFactory
    {
        Discipline dis;
        ConcreteBuilder concreteBuilder;
        Form1 form;
        public ISITFactory(Form1 form1)
        {
            dis = new Discipline();
            concreteBuilder = new ConcreteBuilder(dis);
            form = form1;
        }

        public IAbstractDiscipline CreateDiscipline()
        {
            concreteBuilder.BuildDisciplineNameAndTypePart(form.);
            concreteBuilder.BuildNumbersPart();
            concreteBuilder.BuildProgressAndSpecialityPart();

        }
        public IAbstractLecturer CreateLecturer()
        {
            return new Lecturer();

        }
        public IAbstractBook CreateBook()
        {
            return new Book();

        }
    }
    class POITFactory : IAbstractFactory
    {
        public IAbstractDiscipline CreateDiscipline()
        {
            return new Discipline();
        }
        public IAbstractLecturer CreateLecturer()
        {
            return new Lecturer();
        }
        public IAbstractBook CreateBook()
        {
            return new Book();
        }
    }
    class POIBMSFactory : IAbstractFactory
    {
        public IAbstractDiscipline CreateDiscipline()
        {
            return new Discipline();
        }
        public IAbstractLecturer CreateLecturer()
        {
            return new Lecturer();
        }
        public IAbstractBook CreateBook()
        {
            return new Book();
        }
    }
    class DEWPFactory : IAbstractFactory
    {
        public IAbstractDiscipline CreateDiscipline()
        {
            return new Discipline();

        }
        public IAbstractLecturer CreateLecturer()
        {
            return new Lecturer();
        }
        public IAbstractBook CreateBook()
        {
            return new Book();
        }
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
    class Client
    {
        public void ClientMethod(IAbstractFactory factory)
        {
            var productLecturer = factory.CreateLecturer();
            var productBook = factory.CreateBook();
            var productDiscipline = factory.CreateDiscipline();
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
