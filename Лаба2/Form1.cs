using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Threading;


namespace Лаба2
{
    public partial class Form1 : Form
    {
        List<Discipline> listOfDisciplines = new List<Discipline>();

        public Form1()
        {
            InitializeComponent();
        }

        private void SendAll_Click(object sender, EventArgs e)
        {
            string key = Speciality.SelectedItem.ToString();
            Discipline discipline;
            switch (key)
            {
                case "ИСиТ":
                    discipline = (new Client().ClientMethod(new ISITFactory(this))).GetResult();
                    break;
                /*case "ПОИТ":
                    new Client().ClientMethod(new POITFactory());
                    break;
                case "ПОИБМС":
                    new Client().ClientMethod(new POIBMSFactory());
                    break;
                case "ДЭиВИ":
                    new Client().ClientMethod(new DEWPFactory());
                    break;*/
                default: discipline = new Discipline();
                    break;
            }
            //new Client().ClientMethod();

            //Discipline discipline = 
            #region Discipline form
            /*try
            {
                if (DisciplineName.Text != "")
                {
                    DisciplineName.BackColor = Color.White;
                    discipline.Name = DisciplineName.Text;

                }
                else
                {
                    DisciplineName.BackColor = Color.Salmon;
                    throw new Exception("Please enter Name!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            discipline.NumberOfLaboratories = NumberOfLaboratories.Value;
            discipline.NumberOfLections = NumberOfLections.Value;
            discipline.Semestr = Int32.Parse(Semestr.Text);
            discipline.Year = (int)Year.Value;
            discipline.Speciality = Speciality.SelectedItem.ToString();

            try
            {
                if (Offset.Checked && !Exam.Checked)
                {
                    discipline.TypeOfControl = Offset.Text;

                }
                else if (!Offset.Checked && Exam.Checked)
                {
                    discipline.TypeOfControl = Exam.Text;

                }
                else if (!Offset.Checked && !Exam.Checked)
                {
                    throw new Exception("Please click on radio-button!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }*/
            #endregion

            #region Lecturer form
            /*try
            {
                if (SecondName.Text != "")
                {
                    discipline.lecturer.SecondName = SecondName.Text;
                    SecondName.BackColor = Color.White;
                }
                else
                {
                    SecondName.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch(Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            try
            {
                if (NameOfLecturer.Text != "")
                {
                    discipline.lecturer.Name = NameOfLecturer.Text;
                    NameOfLecturer.BackColor = Color.White;
                }
                else
                {
                    NameOfLecturer.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }

            try
            {
                if (NameOfLecturer.Text != "")
                {
                    discipline.lecturer.Patronymic = Patronymic.Text;
                    Patronymic.BackColor = Color.White;
                }
                else
                {
                    Patronymic.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }

            try
            {
                if (Chair.Text != "")
                {
                    discipline.lecturer.Chair = Chair.Text;
                    Chair.BackColor = Color.White;
                }
                else
                {
                    Chair.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }

            try
            {
                if (Auditory.Text != "")
                {
                    discipline.lecturer.Auditory = Auditory.Text;
                    Auditory.BackColor = Color.White;
                }
                else
                {
                    Auditory.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            #endregion

            #region List of literature form
            Book book = new Book();

            try
            {
                if (NameOfBook.Text != "")
                {
                    book.Name = NameOfBook.Text;
                    NameOfBook.BackColor = Color.White;
                }
                else
                {
                    NameOfBook.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            try
            {
                if (NameOfBook.Text != "")
                {
                    book.Author = Author.Text;
                    Author.BackColor = Color.White;
                }
                else
                {
                    Author.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            try
            {
                if (dateTimePicker1 != null)
                {
                    book.date = dateTimePicker1.Value;
                    //NameOfBook.BackColor = Color.White;
                }
                else
                {
                    //NameOfBook.BackColor = Color.Salmon;
                    throw new Exception("Fill the text box/boxes!");
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            discipline.listOfLiterature = book;
            */
            #endregion

            listOfDisciplines.Add(discipline);
            XmlSerializer xser = new XmlSerializer(typeof(List<Discipline>));
            using (FileStream fileStream = new FileStream("Forms.xml", FileMode.Create))
            {
                xser.Serialize(fileStream, listOfDisciplines);
            }
        }

        private void NumberOfLections_Scroll(object sender, EventArgs e)
        {
            label19.Text = String.Format("Значение: {0}", NumberOfLections.Value);
        }

        private void NumberOfLaboratories_Scroll(object sender, EventArgs e)
        {
            label20.Text = String.Format("Значение: {0}", NumberOfLaboratories.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer xser = new XmlSerializer(typeof(List<Discipline>));
            using (FileStream fileStream = new FileStream("Forms.xml", FileMode.OpenOrCreate))
            {
                xser.Serialize(fileStream, listOfDisciplines);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myForm form = new myForm();
            form.Show();
        }
    }
}
