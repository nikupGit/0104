using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ПР12
{
    public class Async
    {
        public static async Task<string[]> ReadFileAsync(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("Файл не найден");

                using (var reader = new StreamReader(path))
                {
                    var lines = new List<string>();
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                    return lines.ToArray();
                }
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public static void FileWriter(string path, int lineCount)
        {
            using (var writer = new StreamWriter(path, false, Encoding.Unicode))
            {
                for (int i = 1; i <= lineCount; i++)
                {
                    writer.WriteLine($"Строка {i}");
                }
            }
        }
    }
}