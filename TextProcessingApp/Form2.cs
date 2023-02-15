using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TextProcessingApp
{
    public partial class Form2 : Form
    {
        private string _fileText;
        private int _letterNum;
        public Form2(string fileText)
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            _fileText = fileText;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Отметьте галочками действия, которые вы бы хотели выполнить с выбранным файлом и нажмите кнопку Обработать файл";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, _fileText);
            MessageBox.Show(
                    "Файл сохранен",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                while (true)
                {
                    try
                    {
                        _letterNum = Convert.ToInt32(Interaction.InputBox("Введите длину, слова меньше которой вы бы хотели удалить."));
                        break;
                    }
                    catch(System.FormatException)
                    {
                        MessageBox.Show("Нужно ввести число!", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                _fileText = ChangeFile.RemoveWords(_fileText, _letterNum);
            }
            if (checkBox2.Checked)
            {
                _fileText = ChangeFile.RemovePunctuation(_fileText);
            }
            MessageBox.Show(
                    "Файл обработан",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        
    }
}
