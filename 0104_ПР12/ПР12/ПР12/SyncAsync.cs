using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ПР12
{
    public class SyncAsync
    {
        public static async Task<string[]> ReadFileAsync(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
                return Array.Empty<string>();
            }

            var lines = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines.ToArray();
        }

        public static string[] ReadFileSync(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
                return Array.Empty<string>();
            }

            return File.ReadAllLines(path);
        }

        public static void FileWriter(string path, int lineCount)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 1; i <= lineCount; i++)
                {
                    writer.WriteLine(i);
                }
            }
        }
    }
}
