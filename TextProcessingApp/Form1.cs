using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TextProcessingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Здравствуйте, вас приветствует обработчик файлов. Для дальнейшей работы выберите файл.",
                    "Приветствие",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string fileName = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(fileName);
            richTextBox1.Text = fileName;
            DialogResult result = MessageBox.Show(
                    "Перейти в окно обработчика?",
                    "Файл " + fileName.Substring(fileName.LastIndexOf('\\') + 1) + " открыт",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form2 f = new Form2(fileText);
                f.ShowDialog();
            }
        }

    }
}
