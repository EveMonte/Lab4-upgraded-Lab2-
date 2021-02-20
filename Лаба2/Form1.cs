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
                    discipline = (new Client().ClientMethod(ISITFactory.GetInstance(this))).GetResult();
                    break;
                case "ПОИТ":
                    discipline = (new Client().ClientMethod(POITFactory.GetInstance(this))).GetResult();
                    break;
                case "ПОИБМС":
                    discipline = (new Client().ClientMethod(POIBMSFactory.GetInstance(this))).GetResult();
                    break;
                case "ДЭиВИ":
                    discipline = (new Client().ClientMethod(DEWPFactory.GetInstance(this))).GetResult();
                    break;
                default: discipline = new Discipline();
                    break;
            }
          

            listOfDisciplines.Add(discipline);
            listOfDisciplines.Add(discipline.ShallowCopy());
            listOfDisciplines.Add(discipline.DeepCopy());
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
