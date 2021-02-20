using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
namespace Лаба2
{
    public partial class myForm : Form
    {
        private TabControl tabControl;
        private TabPage tabPage;
        public myForm()
        {
            Tabs();
            InitializeComponent();
        }

        private void Tabs()
        {

            int i = 0;

            this.tabControl = new TabControl();
            tabControl.Size = new Size(800, 400);
            tabControl.Location = new Point(1, 1);

            //tabPage.Text = "Page";
            XmlSerializer xser = new XmlSerializer(typeof(List<Discipline>));
            using (FileStream fileStream = new FileStream("Forms.xml", FileMode.OpenOrCreate))
            {
                List<Discipline> newListOfDisciplines = (List<Discipline>)xser.Deserialize(fileStream);
                Control[] tabPages = new Control[newListOfDisciplines.Count];

                foreach (Discipline dis in newListOfDisciplines)
                {
                    tabPage = new TabPage();
                    tabPage.Text = "Page" + i;
                    Label label1 = new Label();
                    Label label2 = new Label();
                    Label label3 = new Label();
                    Label label4 = new Label();
                    Label label5 = new Label();
                    Label label6 = new Label();
                    Label label7 = new Label();
                    Label label8 = new Label();
                    Label label9 = new Label();
                    Label label10 = new Label();
                    Label label11 = new Label();
                    Label label12 = new Label();
                    Label label13 = new Label();
                    Label label14 = new Label();
                    Label label15 = new Label();
                    Label label16 = new Label();
                    tabPage.Controls.AddRange(new Control[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14 });
                    label1.TabIndex = i;
                    label2.TabIndex = i;
                    label3.TabIndex = i;
                    label4.TabIndex = i;
                    label5.TabIndex = i;
                    label6.TabIndex = i;
                    label7.TabIndex = i;
                    label8.TabIndex = i;
                    label9.TabIndex = i;
                    label10.TabIndex = i;
                    label11.TabIndex = i;
                    label12.TabIndex = i;
                    label13.TabIndex = i;
                    label14.TabIndex = i;
                    label15.TabIndex = i;
                    label16.TabIndex = i;

                    label1.Text = dis.Name;
                    label1.Location = new Point(26, 18);

                    label2.Text = dis.Semestr.ToString();
                    label2.Location = new Point(26, 47);

                    label3.Text = dis.Year.ToString();
                    label3.Location = new Point(26, 77);

                    label4.Text = dis.NumberOfLections.ToString();
                    label4.Location = new Point(26, 105);

                    label5.Text = dis.NumberOfLaboratories.ToString();
                    label5.Location = new Point(26, 134);

                    label6.Text = dis.TypeOfControl;
                    label6.Location = new Point(26, 161);

                    label7.Text = dis.lecturer.SecondName;
                    label7.Location = new Point(230, 18);

                    label8.Text = dis.lecturer.Name;
                    label8.Location = new Point(230, 47);

                    label9.Text = dis.lecturer.Patronymic;
                    label9.Location = new Point(230, 77);

                    label10.Text = dis.lecturer.Chair;
                    label10.Location = new Point(230, 105);


                    /*label12.Text = dis.Speciality;
                    label12.Location = new Point(420, 18);*/

                    label11.Text = dis.lecturer.Auditory;
                    label11.Location = new Point(230, 134);

                    label12.Text = dis.listOfLiterature.Name;
                    label12.Location = new Point(420, 18);

                    label13.Text = dis.listOfLiterature.date.ToString();
                    label13.Location = new Point(420, 47);

                    label14.Text = dis.listOfLiterature.Author;
                    label14.Location = new Point(420, 77);
                    tabPages[i] = tabPage;

                    i++;
                }
                tabControl.Controls.AddRange(tabPages);

                this.Controls.AddRange(new Control[] {
    this.tabControl});
            }

        }
    }
}
