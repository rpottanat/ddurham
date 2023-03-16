using Microsoft.Extensions.Logging;
using name_sorter_library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter_library.Service
{
    public interface IFileService
    {
        Task<List<Name>> ReadFromFile(string inputFilePath);
        Task<bool> WriteToFile(string outputFilePath, List<Name> names);
    }
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _log;
        public FileService(ILogger<FileService> log)
        {
            _log = log;
        }
        public async Task<List<Name>> ReadFromFile(string inputFilePath)
        {
            List<Name> names = new List<Name>();

            if (!File.Exists(inputFilePath))
            {
                _log.LogError($"No file exists: {inputFilePath}");
                return names;
            }

            try
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    while (true)
                    {
                        var line = await reader.ReadLineAsync();

                        if (line == null)
                            break;

                        string[] nameParts = line.Split(' ');
                        if (nameParts.Length < 2 || nameParts.Length > 4)
                        {
                            Console.WriteLine($"Invalid name format: {line}");
                            continue;
                        }

                        string lastName = nameParts.Last();
                        string[] givenNames = nameParts.Take(nameParts.Length - 1).ToArray();

                        Name name = new Name(lastName, givenNames);
                        names.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.LogError($"Error reading input file: {ex.Message}");
            }

            names = names.OrderBy(n => n.LastName)
                        .ThenBy(n => n.GivenNames[0])
                        .ThenBy(n => n.GivenNames.ElementAtOrDefault(1))
                        .ThenBy(n => n.GivenNames.ElementAtOrDefault(2))
                        .ToList();
            _log.LogInformation($"Read all the names from the file and sorted {inputFilePath}.");

            return names;
        }

        public async Task<bool> WriteToFile(string outputFilePath, List<Name> names)
        {
            if (!File.Exists(outputFilePath))
            {
                _log.LogError($"No file exists: {outputFilePath}");
                return false;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var name in names)
                    {
                        await writer.WriteLineAsync(name.ToString());
                    }
                }

                _log.LogInformation($"Sorted names written to {outputFilePath}.");
            }
            catch (Exception ex)
            {
                _log.LogError($"Error writing output file: {ex.Message}");
                return false;
            }
            return true;
        }
    }
}
