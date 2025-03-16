using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно с вопросом
            DialogResult result = MessageBox.Show(
            "Вы действительно хотите выйти?", // Текст сообщения
            "Подтверждение выхода",          // Заголовок окна
            MessageBoxButtons.YesNo,         // Кнопки "Да" и "Нет"
            MessageBoxIcon.Question       
            );

            // Если пользователь нажал "Да" (Yes)
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Закрыть приложение
                                    // Или для закрытия текущей формы: this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
