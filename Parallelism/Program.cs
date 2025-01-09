using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceCounter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] filePaths = {
                @"C:\course\file1.txt",
                @"C:\course\file2.txt",
                @"C:\course\file3.txt"}
                ;

            // Параллельное чтение и подсчет пробелов в трех файлах
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = filePaths.Select(path => CountSpacesInFileAsync(path)).ToArray();
            var spaceCounts = await Task.WhenAll(tasks);
            stopwatch.Stop();

            for (int i = 0; i < filePaths.Length; i++)
            {
                Console.WriteLine($"Количество пробелов в файле '{filePaths[i]}': {spaceCounts[i]}");
            }
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");

            // Чтение всех файлов в папке и подсчет пробелов
            Console.WriteLine("Введите путь к папке для подсчета пробелов в файлах:");
            string folderPath = @"C:\course";

            if (Directory.Exists(folderPath))
            {
                stopwatch.Restart();
                int totalSpaces = await CountSpacesInFolderAsync(folderPath);
                stopwatch.Stop();

                Console.WriteLine($"Общее количество пробелов в папке '{folderPath}': {totalSpaces}");
                Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            }
            else
            {
                Console.WriteLine("Папка не найдена.");
            }
        }

        static async Task<int> CountSpacesInFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл '{filePath}' не найден.");
                return 0;
            }

            return await Task.Run(() =>
            {
                string content = File.ReadAllText(filePath);
                return content.Count(c => c == ' ');
            });
        }

        static async Task<int> CountSpacesInFolderAsync(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            var tasks = files.Select(file => CountSpacesInFileAsync(file)).ToArray();
            var results = await Task.WhenAll(tasks);
            return results.Sum();
        }
    }
}