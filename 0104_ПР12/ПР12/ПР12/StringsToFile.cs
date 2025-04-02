using System;
using System.IO;


namespace ПР12
{
    class StringsToFile
    {
        public void WriteLinesToFile(string filePath, int lineCount)
        {
            ValidateParameters(filePath, lineCount);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 1; i <= lineCount; i++)
                {
                    writer.WriteLine("");
                }
            }
        }

        private void ValidateParameters(string filePath, int lineCount)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь к файлу не может быть пустым");

            if (lineCount <= 0)
                throw new ArgumentException("Количество строк должно быть больше 0");
        }
    }
}

