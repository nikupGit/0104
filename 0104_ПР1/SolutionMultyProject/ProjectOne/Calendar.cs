using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOne
{
    public class Calendar
    {
        public static void Main()
        {
            DateTime now = GetCurrentDate();
            //Console.WriteLine($"Today's date is {now}");
            //Console.ReadLine();
            MessageBox.Show($"Today's date is {now}");
        }
        static DateTime GetCurrentDate()
        {
            return DateTime.Now.Date;
        }
    }
}
