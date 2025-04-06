using System;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsResources
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Установка режима отображения изображения
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Отображение строк
            try
            {
                label1.Text = Properties.Resources.String1 + " " + Properties.Resources.String2; // "Строка1 Строка2"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка с текстовыми ресурсами: " + ex.Message);
            }

            // Отображение изображения
            try
            {
                byte[] imageBytes = Properties.Resources.MyImage; // Получение массива байтов
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms); // Преобразование в Image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
            }

            // Отображение RTF
            try
            {
                byte[] rtfBytes = Properties.Resources.MyRtf; // Получение массива байтов
                string rtfContent = Encoding.UTF8.GetString(rtfBytes); // Преобразование в строку
                richTextBox1.Rtf = rtfContent; // Установка содержимого RTF
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки RTF: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}