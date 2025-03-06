using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0104_ПР8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Шаг 2: Создание каталога D:\MyDir\temp и вывод информации
            string dirPath = @"D:\MyDir\temp";
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("Каталог создан: " + dirPath);
            }

            Console.WriteLine("Информация о каталоге:");
            Console.WriteLine("Название: " + dirInfo.Name);
            Console.WriteLine("Полное имя: " + dirInfo.FullName);
            Console.WriteLine("Родительский каталог: " + dirInfo.Parent);
            Console.WriteLine("Диск: " + dirInfo.Root);
            Console.WriteLine("Дата создания: " + dirInfo.CreationTime);
            Console.WriteLine("Атрибуты: " + dirInfo.Attributes);
            Console.WriteLine();

            // Шаг 3: Копирование каталогов из D:\111 в D:\MyDir\temp
            string sourceDir = @"D:\111";
            if (Directory.Exists(sourceDir))
            {
                DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
                foreach (DirectoryInfo subDir in sourceDirInfo.GetDirectories())
                {
                    string destDir = Path.Combine(dirPath, subDir.Name);
                    CopyDirectory(subDir.FullName, destDir);
                }
            }
            else
            {
                Console.WriteLine("Каталог D:\\111 не существует. Создайте его с подкаталогами и файлами.");
                return;
            }

            DisplayFileInfo(dirPath);

            // Шаг 4: Сделать файлы скрытыми
            MakeFilesHidden(dirPath);

            Console.WriteLine("\nПосле изменения атрибутов на скрытые:");
            DisplayFileInfo(dirPath);

            // Шаг 5: Удаление всех подкаталогов
            foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
            {
                subDir.Delete(true); // true для удаления
            }
            Console.WriteLine("Все подкаталоги в " + dirPath + " удалены.");
        }

        static void CopyDirectory(string sourceDir, string destDir)
        {
            // Создаем целевой каталог, если он еще не существует
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            // Копируем все файлы из исходного каталога
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                string tempPath = Path.Combine(destDir, file.Name);
                file.CopyTo(tempPath, true); // Разрешаем перезапись файлов
            }

            // Рекурсивно копируем все подкаталоги
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                string tempPath = Path.Combine(destDir, subdir.Name);
                CopyDirectory(subdir.FullName, tempPath);
            }
        }

        static void DisplayFileInfo(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                foreach (FileInfo file in subDir.GetFiles())
                {
                    Console.WriteLine("Название файла: " + file.Name);
                    Console.WriteLine("Полное имя: " + file.FullName);
                    Console.WriteLine("Расширение: " + file.Extension);
                    Console.WriteLine("Родительский каталог: " + file.DirectoryName);
                    Console.WriteLine("Время создания: " + file.CreationTime);
                    Console.WriteLine("Время последнего доступа: " + file.LastAccessTime);
                    Console.WriteLine("Время последнего изменения: " + file.LastWriteTime);
                    Console.WriteLine("Атрибуты: " + file.Attributes);
                    Console.WriteLine();
                }
            }
        }

        static void MakeFilesHidden(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                foreach (FileInfo file in subDir.GetFiles())
                {
                    File.SetAttributes(file.FullName, File.GetAttributes(file.FullName) | FileAttributes.Hidden);
                }
            }
        }
    }
}