using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

[assembly: NeutralResourcesLanguage("en")]

namespace PRRes
{
    public class Program
    {
        static void Main()
        {
            string[] cultures = { "en-CA", "en-US", "fr-FR", "ru-RU" };
            Random rnd = new Random();
            int cultureIndex = rnd.Next(0, cultures.Length);

            CultureInfo originalCulture = Thread.CurrentThread.CurrentUICulture;

            try
            {
                CultureInfo newCulture = new CultureInfo(cultures[cultureIndex]);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;

                ResourceManager rm = new ResourceManager("PRRes.Greeting", typeof(Program).Assembly);
                string greeting = rm.GetString("HelloString");

                string message = $"Current culture: {Thread.CurrentThread.CurrentUICulture.Name}\n{greeting}";
                MessageBox.Show(message, "Localized Greeting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (CultureNotFoundException ex)
            {
                MessageBox.Show($"Culture error: {ex.InvalidCultureName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
            Console.ReadLine();
        }
    }
}