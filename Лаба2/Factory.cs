using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2
{
    //Абстрактная фабрика
    interface IAbstractFactory
    {
        ConcreteBuilder CreateDiscipline();
        ConcreteBuilder CreateLecturer();
        ConcreteBuilder CreateBook();
        ConcreteBuilder Merge();
    }

    //Абстрактные интерфейсы для продуктов, входящих в одну фабрику
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

    //Фабрики, которые реализуют общий интерфейс IFactory
    class ISITFactory : IAbstractFactory
    {
        Discipline dis;
        ConcreteBuilder concreteBuilder;
        Form1 form;
        //Finder find;

        private ISITFactory(Form1 form1)
        {
            dis = new Discipline();
            concreteBuilder = new ConcreteBuilder(dis);
            form = form1;
            //find = new Finder();
        }
        public static ISITFactory GetInstance(Form1 form1)
        {
            if (_instance == null)
            {
                _instance = new ISITFactory(form1);
            }
            return _instance;
        }
        private static ISITFactory _instance;
        public ConcreteBuilder CreateDiscipline()
        {
            concreteBuilder.BuildDisciplineNameAndTypePart(Finder.FindElementsInForm("DisciplineName", "TextBox", form), Finder.FindElementsInForm("", "RadioButton", form));
            concreteBuilder.BuildNumbersPart(Int32.Parse(Finder.FindElementsInForm("NumberOfLections", "TrackBar", form)), Int32.Parse(Finder.FindElementsInForm("NumberOfLaboratories", "TrackBar", form)));
            concreteBuilder.BuildProgressAndSpecialityPart(Int32.Parse(Finder.FindElementsInForm("Year", "NumericUpDown", form)), Int32.Parse(Finder.FindElementsInForm("Semestr", "ComboBox", form)), Finder.FindElementsInForm("Speciality", "ListBox", form));
            return concreteBuilder;
        }
        public ConcreteBuilder CreateLecturer()
        {
            concreteBuilder.BuildLecturerFIOPart(Finder.FindElementsInForm("SecondName", "TextBox", form), Finder.FindElementsInForm("NameOfLecturer", "TextBox", form), Finder.FindElementsInForm("Patronymic", "TextBox", form));
            concreteBuilder.BuildLecturerAnotherPart(Finder.FindElementsInForm("Chair", "TextBox", form), Finder.FindElementsInForm("Auditory", "TextBox", form));
            return concreteBuilder;

        }
        public ConcreteBuilder CreateBook()
        {
            concreteBuilder.BuildBookPart(Finder.FindElementsInForm("NameOfBook", "TextBox", form), Finder.FindElementsInForm("Author", "TextBox", form), DateTime.Parse(Finder.FindElementsInForm("dateTimePicker1", "DateTimePicker", form)));
            return concreteBuilder;

        }
        public ConcreteBuilder Merge()
        {
            concreteBuilder.Merge();
            return concreteBuilder;
        }
    }
    class POITFactory : IAbstractFactory
    {
        Discipline dis;
        ConcreteBuilder concreteBuilder;
        Form1 form;
        //Finder find;

        private POITFactory(Form1 form1)
        {
            dis = new Discipline();
            concreteBuilder = new ConcreteBuilder(dis);
            form = form1;
            //find = new Finder();
        }
        public static POITFactory GetInstance(Form1 form1)
        {
            if (_instance == null)
            {
                _instance = new POITFactory(form1);
            }
            return _instance;
        }
        private static POITFactory _instance;
        public ConcreteBuilder CreateDiscipline()
        {
            concreteBuilder.BuildDisciplineNameAndTypePart(Finder.FindElementsInForm("DisciplineName", "TextBox", form), Finder.FindElementsInForm("", "RadioButton", form));
            concreteBuilder.BuildNumbersPart(Int32.Parse(Finder.FindElementsInForm("NumberOfLections", "TrackBar", form)), Int32.Parse(Finder.FindElementsInForm("NumberOfLaboratories", "TrackBar", form)));
            concreteBuilder.BuildProgressAndSpecialityPart(Int32.Parse(Finder.FindElementsInForm("Year", "NumericUpDown", form)), Int32.Parse(Finder.FindElementsInForm("Semestr", "ComboBox", form)), Finder.FindElementsInForm("Speciality", "ListBox", form));
            return concreteBuilder;
        }
        public ConcreteBuilder CreateLecturer()
        {
            concreteBuilder.BuildLecturerFIOPart(Finder.FindElementsInForm("SecondName", "TextBox", form), Finder.FindElementsInForm("NameOfLecturer", "TextBox", form), Finder.FindElementsInForm("Patronymic", "TextBox", form));
            concreteBuilder.BuildLecturerAnotherPart(Finder.FindElementsInForm("Chair", "TextBox", form), Finder.FindElementsInForm("Auditory", "TextBox", form));
            return concreteBuilder;

        }
        public ConcreteBuilder CreateBook()
        {
            concreteBuilder.BuildBookPart(Finder.FindElementsInForm("NameOfBook", "TextBox", form), Finder.FindElementsInForm("Author", "TextBox", form), DateTime.Parse(Finder.FindElementsInForm("dateTimePicker1", "DateTimePicker", form)));
            return concreteBuilder;

        }
        public ConcreteBuilder Merge()
        {
            concreteBuilder.Merge();
            return concreteBuilder;
        }
    }
    class POIBMSFactory : IAbstractFactory
    {
        Discipline dis;
        ConcreteBuilder concreteBuilder;
        Form1 form;
        //Finder find;

        private POIBMSFactory(Form1 form1)
        {
            dis = new Discipline();
            concreteBuilder = new ConcreteBuilder(dis);
            form = form1;
            //find = new Finder();
        }
        public static POIBMSFactory GetInstance(Form1 form1)
        {
            if (_instance == null)
            {
                _instance = new POIBMSFactory(form1);
            }
            return _instance;
        }
        private static POIBMSFactory _instance;
        public ConcreteBuilder CreateDiscipline()
        {
            concreteBuilder.BuildDisciplineNameAndTypePart(Finder.FindElementsInForm("DisciplineName", "TextBox", form), Finder.FindElementsInForm("", "RadioButton", form));
            concreteBuilder.BuildNumbersPart(Int32.Parse(Finder.FindElementsInForm("NumberOfLections", "TrackBar", form)), Int32.Parse(Finder.FindElementsInForm("NumberOfLaboratories", "TrackBar", form)));
            concreteBuilder.BuildProgressAndSpecialityPart(Int32.Parse(Finder.FindElementsInForm("Year", "NumericUpDown", form)), Int32.Parse(Finder.FindElementsInForm("Semestr", "ComboBox", form)), Finder.FindElementsInForm("Speciality", "TextBox", form));
            return concreteBuilder;
        }
        public ConcreteBuilder CreateLecturer()
        {
            concreteBuilder.BuildLecturerFIOPart(Finder.FindElementsInForm("SecondName", "TextBox", form), Finder.FindElementsInForm("NameOfLecturer", "TextBox", form), Finder.FindElementsInForm("Patronymic", "ListBox", form));
            concreteBuilder.BuildLecturerAnotherPart(Finder.FindElementsInForm("Chair", "TextBox", form), Finder.FindElementsInForm("Auditory", "TextBox", form));
            return concreteBuilder;

        }
        public ConcreteBuilder CreateBook()
        {
            concreteBuilder.BuildBookPart(Finder.FindElementsInForm("NameOfBook", "TextBox", form), Finder.FindElementsInForm("Author", "TextBox", form), DateTime.Parse(Finder.FindElementsInForm("dateTimePicker1", "DateTimePicker", form)));
            return concreteBuilder;

        }
        public ConcreteBuilder Merge()
        {
            concreteBuilder.Merge();
            return concreteBuilder;
        }
    }
    class DEWPFactory : IAbstractFactory
    {
        Discipline dis;
        ConcreteBuilder concreteBuilder;
        Form1 form;
        //Finder find;

        private DEWPFactory(Form1 form1)
        {
            dis = new Discipline();
            concreteBuilder = new ConcreteBuilder(dis);
            form = form1;
            //find = new Finder();
        }
        public static DEWPFactory GetInstance(Form1 form1)
        {
            if (_instance == null)
            {
                _instance = new DEWPFactory(form1);
            }
            return _instance;
        }
        private static DEWPFactory _instance;
        public ConcreteBuilder CreateDiscipline()
        {
            concreteBuilder.BuildDisciplineNameAndTypePart(Finder.FindElementsInForm("DisciplineName", "TextBox", form), Finder.FindElementsInForm("", "RadioButton", form));
            concreteBuilder.BuildNumbersPart(Int32.Parse(Finder.FindElementsInForm("NumberOfLections", "TrackBar", form)), Int32.Parse(Finder.FindElementsInForm("NumberOfLaboratories", "TrackBar", form)));
            concreteBuilder.BuildProgressAndSpecialityPart(Int32.Parse(Finder.FindElementsInForm("Year", "NumericUpDown", form)), Int32.Parse(Finder.FindElementsInForm("Semestr", "ComboBox", form)), Finder.FindElementsInForm("Speciality", "ListBox", form));
            return concreteBuilder;
        }
        public ConcreteBuilder CreateLecturer()
        {
            concreteBuilder.BuildLecturerFIOPart(Finder.FindElementsInForm("SecondName", "TextBox", form), Finder.FindElementsInForm("NameOfLecturer", "TextBox", form), Finder.FindElementsInForm("Patronymic", "TextBox", form));
            concreteBuilder.BuildLecturerAnotherPart(Finder.FindElementsInForm("Chair", "TextBox", form), Finder.FindElementsInForm("Auditory", "TextBox", form));
            return concreteBuilder;

        }
        public ConcreteBuilder CreateBook()
        {
            concreteBuilder.BuildBookPart(Finder.FindElementsInForm("NameOfBook", "TextBox", form), Finder.FindElementsInForm("Author", "TextBox", form), DateTime.Parse(Finder.FindElementsInForm("dateTimePicker1", "DateTimePicker", form)));
            return concreteBuilder;

        }
        public ConcreteBuilder Merge()
        {
            concreteBuilder.Merge();
            return concreteBuilder;
        }
    }
}
