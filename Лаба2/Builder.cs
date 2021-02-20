using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба2
{
    //Общий интерфейс строителя
    public interface IBuilder
    {
        void BuildDisciplineNameAndTypePart(string disName, string typeOfControl);
        void BuildNumbersPart(int lections, int laboratories);
        void BuildProgressAndSpecialityPart(int year, int semestr, string speciality);
        void BuildLecturerFIOPart(string second, string name, string patronymic);
        void BuildLecturerAnotherPart(string chair, string auditory);
        void BuildBookPart(string name, string author, DateTime dateTime);
    }

    //Конкретный строитель, вообще для паттерна нужно больше строителей, но как бэ зачем мне здесь больше одного, у меня все однотипно
    public class ConcreteBuilder : IBuilder
    {
        private Discipline discipline = new Discipline();
        private Lecturer lecturer = new Lecturer();
        private Book book = new Book();
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
            lecturer.SecondName = second;
            lecturer.Name = name;
            lecturer.Patronymic = patronymic;
        }
        public void BuildLecturerAnotherPart(string chair, string auditory)
        {
            lecturer.Chair = chair;
            lecturer.Auditory = auditory;
        }
        public void BuildBookPart(string name, string author, DateTime dateTime)
        {
            book.Name = name;
            book.Author = author;
            book.date = dateTime;
        }
        public void Merge()
        {
            discipline.lecturer = lecturer;
            discipline.listOfLiterature = book;
        }

        public Discipline GetResult()
        {
            Discipline result = this.discipline;
            this.Reset();
            return result;
        }
    }
}
