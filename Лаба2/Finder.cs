using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Лаба2
{
    public static class Finder
    {
        public static string FindElementsInForm(string elementsName, string elementsType, Form1 form)
        {
            switch (elementsType)
            {
                case "TextBox":
                    foreach (object textBox in form.Controls)
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
}
