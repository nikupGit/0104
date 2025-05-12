using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ConsoleWeb
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Конвертер валют");
            Console.Write("Введите исходную валюту (например USD): ");
            string fromCurrency = Console.ReadLine().ToUpper();

            Console.Write("Введите целевую валюту (например EUR): ");
            string toCurrency = Console.ReadLine().ToUpper();

            Console.Write("Введите сумму: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            string googleUrl = $"https://www.google.com/search?q={Uri.EscapeDataString($"{amount} {fromCurrency} в {toCurrency}")}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(googleUrl);
                    JObject data = JObject.Parse(json);

                    if ((bool)data["success"])
                    {
                        decimal result = (decimal)data["result"];
                        Console.WriteLine($"{amount} {fromCurrency} = {result:F2} {toCurrency}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: " + data["error"]["info"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }
    }
}