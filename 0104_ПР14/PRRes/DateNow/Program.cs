using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateNow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            DateTime Date = DateTime.Now;

            PrintLocalizedDate(Date, "ru-RU", "Русский:");
            PrintLocalizedDate(Date, "en-US", "Английский:");
        }

        static void PrintLocalizedDate(DateTime date, string culture, string language)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);

            string formattedDate = date.ToString("D", cultureInfo);

            Console.WriteLine($"{language} {formattedDate}");
        }
    }
}

