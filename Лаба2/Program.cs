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
        ConcreteBuilder CreateDiscipline();
        ConcreteBuilder CreateLecturer();
        ConcreteBuilder CreateBook();
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

    public static class Finder 
    { 
        public static string FindElementsInForm(string elementsName, string elementsType, Form1 form)
        {
            switch (elementsType)
            {
                case "TextBox":
                    foreach(object textBox in form.Controls)
                    {
                        if (textBox is TextBox)
                        {
                            TextBox newTextBox = (TextBox)textBox;
                            if (newTextBox.Name == elementsName)
                            {
                                return newTextBox.Text;
                            }

                        }
                    }

                    break;
                case "ComboBox":
                    foreach (object comboBox in form.Controls)
                    {
                        if (comboBox is ComboBox)
                        {
                            ComboBox newComboBox = (ComboBox)comboBox;
                            if (newComboBox.Name == elementsName)
                            {
                                return newComboBox.Text;
                            }
                        }
                        
                    }
                    break;
                case "ListBox":
                    foreach (object listBox in form.Controls)
                    {
                        if (listBox is ListBox)
                        {
                            ListBox newListBox = (ListBox)listBox;
                            if (newListBox.Name == elementsName)
                            {
                                return newListBox.SelectedItem.ToString();
                            }
                        }
                        
                    }
                    break;
                case "NumericUpDown":
                    foreach (object numericUpDown in form.Controls)
                    {
                        if (numericUpDown is NumericUpDown)
                        {
                            NumericUpDown newNumericUpDown = (NumericUpDown)numericUpDown;
                            if (newNumericUpDown.Name == elementsName)
                            {
                                return newNumericUpDown.Text;
                            }
                        }
                        
                    }
                    break;
                case "DateTimePicker":
                    foreach (object dateTimePicker in form.Controls)
                    {
                        if (dateTimePicker is DateTimePicker)
                        {
                            DateTimePicker newDateTimePicker = (DateTimePicker)dateTimePicker;
                            if (newDateTimePicker.Name == elementsName)
                            {
                                return newDateTimePicker.Value.ToString();
                            }
                        }
                    }
                    break;
                case "RadioButton":
                    foreach (object radioButton in form.Controls)
                    {
                        if (radioButton is RadioButton)
                        {
                            RadioButton newRadioButton = (RadioButton)radioButton;
                            if (newRadioButton.Checked)
                            {
                                return newRadioButton.Name;
                            }
                        }
                    }
                    break;
                case "TrackBar":
                    foreach (object trackBar in form.Controls)
                    {
                        if (trackBar is TrackBar)
                        {
                            TrackBar newTrackBar = (TrackBar)trackBar;
                            if (newTrackBar.Name == elementsName)
                            {
                                return newTrackBar.Value.ToString();
                            }
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
        //Finder find;

        public ISITFactory(Form1 form1)
        {
            dis = new Discipline();
            concreteBuilder = new ConcreteBuilder(dis);
            form = form1;
            //find = new Finder();
        }

        public ConcreteBuilder CreateDiscipline()
        {
            concreteBuilder.BuildDisciplineNameAndTypePart(Finder.FindElementsInForm("DisciplineName", "TextBox", form), Finder.FindElementsInForm("", "RadioButton", form));
            concreteBuilder.BuildNumbersPart(Int32.Parse(Finder.FindElementsInForm("NumberOfLections", "TrackBar", form)), Int32.Parse(Finder.FindElementsInForm("NumberOfLaboratories", "TrackBar", form)));
            concreteBuilder.BuildProgressAndSpecialityPart(Int32.Parse(Finder.FindElementsInForm("Year", "NumericUpDown", form)), Int32.Parse(Finder.FindElementsInForm("Semestr", "ComboBox", form)), Finder.FindElementsInForm("Speciality", "TextBox", form));
            return concreteBuilder;
        }
        public ConcreteBuilder CreateLecturer()
        {

            return concreteBuilder;

        }
        public ConcreteBuilder CreateBook()
        {
            return concreteBuilder;

        }
    }
    /*class POITFactory : IAbstractFactory
    {
        public ConcreteBuilder CreateDiscipline()
        {
            return new ConcreteBuilder();
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
        public void CreateDiscipline()
        {
            //return new Discipline();
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
        public void CreateDiscipline()
        {
            //return new Discipline();

        }
        public IAbstractLecturer CreateLecturer()
        {
            return new Lecturer();
        }
        public IAbstractBook CreateBook()
        {
            return new Book();
        }
    }*/

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
        public ConcreteBuilder ClientMethod(IAbstractFactory factory)
        {
            //factory.CreateLecturer();
            //var productBook = factory.CreateBook();
            factory.CreateDiscipline();
            return factory.CreateDiscipline();
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
