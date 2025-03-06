//1. Разработать консольное приложение «Текстовый калькулятор»,
//которое будет иметь два сцеплять две введенные строки.
//Сцепленная строка также должна выводиться.
//2. Реализовать возможность ведения лог-файла,
//в котором будет фиксироваться информация о производимых пользователем действиях
//(вводе строк, фактах выполнения операции сцепления с фиксацией количества раз выполнения сцепления, фактах завершения работы приложения).
//Каждый лог-файл должен создаваться на текущую дату, т.е. для каждого дня будет свой один лог-файл.
//3. Реализовать сохранение выполненных сцеплений для каждого сеанса работы калькулятора в файле result.txt.
//После завершения работы калькулятора файл с результатами должен сохраняться в подкаталоге Results текущего каталога с добавлением к имени файла даты и времени завершения его формирования.
//При работе с файлами обеспечить обработку всех возможных ошибок.


using System;
using System.Collections.Generic;
using System.IO;


namespace ПР9_Console_
{
    internal class Program
        {
        #region Объявление ключевых значений
        static List<string> concatenatedResults = new List<string>();
        static int concatenationCount = 0;
        static Logger logger = new Logger();
        #endregion

        static void Main(string[] args)
        {
            logger.Log("Приложение запущено.");

            try
            {
            #region Работа приложения
            bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("Ввод осуществлять на английском.");
                    Console.WriteLine("\nВведите первую строку (или 'exit' для завершения):");
                    string str1 = Console.ReadLine();
                    if (str1.ToLower() == "exit")
                    {
                        isRunning = false;
                        break;
                    }
                    logger.Log($"Пользователь ввел первую строку: {str1}");

                    Console.WriteLine("Введите вторую строку:");
                    string str2 = Console.ReadLine();
                    logger.Log($"Пользователь ввел вторую строку: {str2}");

                    string result = ConcatenateStrings(str1, str2);
                    Console.WriteLine($"Результат сцепления: {result}");

                    concatenatedResults.Add(result);
                    concatenationCount++;
                    logger.Log($"Сцепление выполнено. Всего операций: {concatenationCount}");
                }

                SaveResults();
                logger.Log("Приложение завершает работу.");
                #endregion
            }
            catch (Exception ex)
            {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    logger.Log($"Ошибка: {ex.Message}");
            }
        }
        #region Функции
        static string ConcatenateStrings(string str1, string str2)
        {
            return str1 + str2;
        }

        static void SaveResults()
        {
            string resultsDir = Path.Combine(Directory.GetCurrentDirectory(), "Results");
            try
            {
                Directory.CreateDirectory(resultsDir);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string filePath = Path.Combine(resultsDir, $"result_{timestamp}.txt");

                File.WriteAllLines(filePath, concatenatedResults);
                logger.Log($"Результаты сохранены в {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
                logger.Log($"Ошибка сохранения: {ex.Message}");
            }
        }
        #endregion
    }
    #region Класс Logger для записи лога
    class Logger
    {
        public void Log(string message)
        {
            string logFileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), logFileName);

            try
            {
                File.AppendAllText(logPath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи лога: {ex.Message}");
            }
        }
    }
    #endregion
}